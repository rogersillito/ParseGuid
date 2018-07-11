using System;
using System.Linq;
using System.Windows.Forms;

namespace ParseGuid
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var parser = new Program();
            if (!args.Any() || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("FAILED TO SUPPLY A GUID PARAMETER\n");
                parser.NewGuidToClipboard();
                return;
            }
            parser.ParseGuid(args[0]);
        }

        private void NewGuidToClipboard()
        {
            var newGuid = Guid.NewGuid().ToString();
            Clipboard.SetText(newGuid);
            Console.WriteLine($"{newGuid}   <--- A NEW guid has been copied to clipboard");
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
