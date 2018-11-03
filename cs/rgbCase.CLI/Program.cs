using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgbCase.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string ret;

            Console.WriteLine("rgbCase CLI client");

            CtrlInterface iface = new CtrlInterface();
            try
            {
                Settings.Load();

                bool bConsole = true;

                if (args.Length > 0)
                {
                    iface.Evaluate(string.Join(" ", args), out ret);
                    Console.WriteLine(ret);
                    return;
                }

                Console.WriteLine("Enter commands (try 'h'):");
                while (bConsole)
                {
                    string input = Console.ReadLine();
                    bConsole = iface.Evaluate(input, out ret);
                    Console.WriteLine(ret);
                }
            }
            finally
            {
                Settings.Save();
                iface.Dispose();
            }
        }
    }
}
