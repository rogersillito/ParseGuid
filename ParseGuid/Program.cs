using System;
using System.Linq;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("FAILED TO SUPPLY A GUID PARAMETER");
                return;
            }
            new Program().ParseGuid(args[0]);
        }

        public void ParseGuid(string guidStr)
        {
            Guid guid;
            string parsed = null;
            if (!Guid.TryParse(guidStr, out guid))
            {
                Console.WriteLine("FAILED TO PARSE GUID");
                return;
            }
            switch (guidStr.Length)
            {
                case 32:
                    parsed = guid.ToString();
                    break;
                case 36:
                    parsed = guid.ToString("N");
                    break;
                case 38:
                    parsed = guidStr.Trim('{', '}');
                    break;
            }
            Clipboard.SetText(parsed);
            Console.WriteLine($"{parsed}   <--- Value has been copied to clipboard");
        }
    }
}
