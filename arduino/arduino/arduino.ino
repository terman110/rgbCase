/// Serial message protocol
/// =======================
///
/// Each message contains of 6 byte.
///
/// Start Byte | Type Byte | Data Byte 0 | Data Byte 1 | Data Byte 2 | End Byte
/// 0x0f       | 0x..      | 0x..        | 0x..        | 0x..        | 0xff
///
/// Message         | Type Byte | Data Byte 0 | Data Byte 1 | Data Byte 2
/// Heart Beat Req. | 0x00      | 0x00        | 0x00        | 0x00
/// Heart Beat Ack. | 0x01      | 0x00        | 0x00        | 0x00
/// Brightness Req. | 0x02      | value       | 0x00        | 0x00
/// Brightness Ack. | 0x03      | value       | 0x00        | 0x00
/// Mode Req.       | 0x04      | value       | param 0     | param 1
/// Mode Ack.       | 0x05      | value       | param 0     | param 1
/// Color Req.      | 0x06      | red         | green       | blue
/// Color Ack.      | 0x07      | red         | green       | blue
/// Error           | 0xff      | err code 0  | err code 1  | err code 2

#define GAMMA_CORRECTION

#include <avr/io.h> 
#include <avr/wdt.h>
#include <EEPROM.h>
#include <Bounce2.h>

#ifdef GAMMA_CORRECTION
const uint8_t PROGMEM gamma8[] = {
    0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
    0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,
    1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2,  2,  2,  2,  2,
    2,  3,  3,  3,  3,  3,  3,  3,  4,  4,  4,  4,  4,  5,  5,  5,
    5,  6,  6,  6,  6,  7,  7,  7,  7,  8,  8,  8,  9,  9,  9, 10,
   10, 10, 11, 11, 11, 12, 12, 13, 13, 13, 14, 14, 15, 15, 16, 16,
   17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 23, 24, 24, 25,
   25, 26, 27, 27, 28, 29, 29, 30, 31, 32, 32, 33, 34, 35, 35, 36,
   37, 38, 39, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 50,
   51, 52, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 66, 67, 68,
   69, 70, 72, 73, 74, 75, 77, 78, 79, 81, 82, 83, 85, 86, 87, 89,
   90, 92, 93, 95, 96, 98, 99,101,102,104,105,107,109,110,112,114,
  115,117,119,120,122,124,126,127,129,131,133,135,137,138,140,142,
  144,146,148,150,152,154,156,158,160,162,164,167,169,171,173,175,
  177,180,182,184,186,189,191,193,196,198,200,203,205,208,210,213,
  215,218,220,223,225,228,231,233,236,239,241,244,247,249,252,255 };
#endif // GAMMA_CORRECTION

//Setup Output
#define ledPin_r 5
#define ledPin_g 6
#define ledPin_b 3

int inputByte_0 = 0;
int inputByte_1 = 0;
int inputByte_2 = 0;
int inputByte_3 = 0;
int inputByte_4 = 0;
int inputByte_5 = 0;

byte brightness = 196;
byte red = 255;
byte green = 128;
byte blue = 128;
byte mode = 1;  // 0: PC send; 1: Breathing; 2: Color Circle; 3: Breathing Circle
byte mode_p0 = 0; // breating: delay; Color Circle: delay; Breathing Circle: delay
byte mode_p1 = 0; // breating: minBrightness; Color Circle: 0; Breathing Circle: minBrightness

bool mode_forward = true;

const int serialReadTimeout_us = 25;

unsigned long lastCmd;
unsigned long lastEEPROM;

//  Debounce button object
int pinBtn = 13;
Bounce debouncer = Bounce();

//Setup
void setup()
{  
  pinMode(ledPin_r, OUTPUT);
  pinMode(ledPin_g, OUTPUT);
  pinMode(ledPin_b, OUTPUT);
  
  pinMode(pinBtn, INPUT);
  digitalWrite(pinBtn, HIGH);
  debouncer.attach(pinBtn);
  debouncer.interval(5);

  Serial.begin(115200);
  
  lastCmd = millis();
  lastEEPROM = millis();
  
  ReadEEPROM();
}

//Main Loop
void loop()
{
  if ( debouncer.update() && debouncer.read() == HIGH)
  {
    if(mode >= 3) mode = 0;
    else ++mode;
    Serial.write("Mode changed: ");
    Serial.write(48+(int)mode);
    Send(0x05, mode, 0x00, 0x00);
    WriteEEPROM();
  }
  
  // Handling messages has highest priority
  HandleBuffer();

  switch(mode)
  {
    case 1: Breathing(); break;
    case 2: ColorCircle(); break;
    case 3: BreathingCircle(); break;
  }
  
  SetColor(brightness, red, green, blue);

  unsigned long duration_ms = millis() - lastEEPROM;
  if(duration_ms >= 900000 || duration_ms < 0)
    WriteEEPROM();
}

bool HasToChangeMode(byte vmin, byte vmax, bool forward)
{
  return ((brightness <= mode_p1 && !forward) || (brightness >= 255 && forward));
}

void Breathing()
{
  if (HasToChangeMode(mode_p1, 255, mode_forward))
      mode_forward = !mode_forward;
  brightness = (byte)((int)brightness + (mode_forward ? 1 : -1));
  if (mode_p0 < 2)
    mode_p0 = 2;
  delay(mode_p0);
}

void ColorCircle_Init()
{
    red = 0;
    green = 0;
    blue = 0;
    if (brightness < 10)
        brightness = 255;
    mode_p1 = 0;
}

void ColorCircle()
{
  switch (mode_p1)
  {
      case 0:
          if (red >= 254) mode_p1 = 1;
          ++red;
          break;
      case 1:
          if (blue >= 254) mode_p1 = 2;
          ++blue;
          break;
      case 2:
          if (green >= 254) mode_p1 = 3;
          ++green;
          break;
      case 3:
          if (red <= 1) mode_p1 = 4;
          --red;
          break;
      case 4:
          if (blue <= 1) mode_p1 = 5;
          --blue;
          break;
      case 5:
          if (green <= 1) mode_p1 = 0;
          --green;
          break;
  }
  if (mode_p0 < 2)
    mode_p0 = 2;
  delay(mode_p0);
}

void BreathingCircle_Init()
{
    red = (byte)random(255);
    green = (byte)random(255);
    blue = (byte)random(255);
    if (brightness < 10)
        brightness = 255;
    mode_p1 = 0;
}

void BreathingCircle()
{
  if (HasToChangeMode(mode_p1, 255, mode_forward))
      mode_forward = !mode_forward;

  if (brightness <= mode_p1)
  {
    red = (byte)random(255);
    green = (byte)random(255);
    blue = (byte)random(255);
  }
      
  brightness = (byte)((int)brightness + (mode_forward ? 1 : -1));
  if (mode_p0 < 2)
    mode_p0 = 2;
  delay(mode_p0);
}

void(* resetFunc) (void) = 0; //declare reset function @ address 0

bool HandleBuffer()
{
  if (Serial.available() >= 6)
  {
    while(inputByte_0 == 0 && Serial.peek() != 0x0f)
      Serial.read();
      
    //Read buffer
    inputByte_0 = Serial.read();
    delayMicroseconds(serialReadTimeout_us);
    inputByte_1 = Serial.read();
    delayMicroseconds(serialReadTimeout_us);
    inputByte_2 = Serial.read();
    delayMicroseconds(serialReadTimeout_us);
    inputByte_3 = Serial.read();
    delayMicroseconds(serialReadTimeout_us);
    inputByte_4 = Serial.read();
    delayMicroseconds(serialReadTimeout_us);
    inputByte_5 = Serial.read();
  }

  //Check for start of Message
  if (inputByte_0 == 0x0f && inputByte_5 == 0xff)
  {    
    //Detect Command type
    switch (inputByte_1)
    {
      case 0x00: // Heart beat
        Send(0x01, 0x00, 0x00, 0x00);
        break;
      case 0x02: // Brightness
        brightness = inputByte_2;
        Send(0x03, brightness, 0x00, 0x00);
        break;
      case 0x04: // Mode
        mode = inputByte_2;
        mode_p0 = inputByte_3;
        mode_p1 = inputByte_4;
        Send(0x05, mode, 0x00, 0x00);
        switch(mode)
        {
          case 2: ColorCircle_Init(); break;
          case 3: BreathingCircle_Init(); break;
        }
        WriteEEPROM();
        break;
      case 0x06: // Color
        red = inputByte_2;
        green = inputByte_3;
        blue = inputByte_4;
        Send(0x07, red, green, blue);
        break;
    }
    lastCmd = millis();

    inputByte_0 = 0;
    inputByte_1 = 0;
    inputByte_2 = 0;
    inputByte_3 = 0;
    inputByte_4 = 0;
    inputByte_5 = 0;
  }
  else if(millis() - lastCmd > 360000)
  {
    Send(0xff, 0x0f, 0x0f, 0x0f);
    wdt_enable(WDTO_1S);
  }
}

static void SetColor(int brightness, int red, int green, int blue)
{
#ifdef GAMMA_CORRECTION
  analogWrite(ledPin_r, pgm_read_byte_near(&gamma8[red  ]) * brightness / 255);
  analogWrite(ledPin_g, pgm_read_byte_near(&gamma8[green]) * brightness / 255);
  analogWrite(ledPin_b, pgm_read_byte_near(&gamma8[blue ]) * brightness / 255);
#else // GAMMA_CORRECTION
  analogWrite(ledPin_r, red   * brightness / 255));
  analogWrite(ledPin_g, green * brightness / 255));
  analogWrite(ledPin_b, blue  * brightness / 255));
#endif // GAMMA_CORRECTION
}

static void Send(byte bType, byte bD0, byte bD1, byte bD2)
{
  byte buf[6];
  buf[0] = 0x0f;
  buf[1] = bType;
  buf[2] = bD0;
  buf[3] = bD1;
  buf[4] = bD2;
  buf[5] = 0xff;
  Serial.write(buf, 6);
}

void WriteEEPROM()
{
  EEPROM.write(0, brightness);
  EEPROM.write(1, red);
  EEPROM.write(2, green);
  EEPROM.write(3, blue);
  EEPROM.write(4, mode);
  EEPROM.write(5, mode_p0);
  EEPROM.write(6, mode_p1);
}

void ReadEEPROM()
{
  brightness = EEPROM.read(0);
  red = EEPROM.read(1);
  green = EEPROM.read(2);
  blue = EEPROM.read(3);
  mode = EEPROM.read(4);
  mode_p0 = EEPROM.read(5);
  mode_p1 = EEPROM.read(6);
}

