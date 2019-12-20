using System;
using System.Collections.Generic;
using System.Text;
using CompilerDLL;

namespace SharpConsole
{
    class Program
    {
        const string header = @"
        using System;
        using System.IO;
        using System.Net;
        using System.Threading;
        using System.Collections.Generic;
 
        namespace CScript
        {
            public class Script
            {
                public static void Main()
                {
        ";
        const string footer = @"
                                }
                            }
                        }";

        static void Main(string[] args)
        {
            Console.Title = "SharpConsole";

            List<string> code = new List<string>();
            var compiler = new Compiler();
            while (true)
            {
                Console.Write("csharp> ");
                string line = Console.ReadLine();
                switch (line)
                {
                    case "!run":
                        {
                            compiler.ExecuteScript(FormatSources(code));
                            foreach (string er in compiler.errors)
                                Console.WriteLine(er);
                            foreach (string ou in compiler.output)
                                Console.WriteLine(ou);
                        }
                        break;
     
                    default:
                        {
                            code.Add(line);
                        }
                        break;
                }



            }
        }

        private static string FormatSources(List<string> code)
        {
            string program = header;
            StringBuilder sb = new StringBuilder(program);

            foreach (var sc in code)
            {
                sb.AppendLine(sc);
            }
            sb.AppendLine(footer);
            return sb.ToString();
        }
    }
}