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
                    Console.WriteLine(""Hello!!!!!"");
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
                            //получение ошибок 
                            var errors = compiler.errors;
                            //получение выходных данных
                            var outputs = compiler.output;
                            //вывод
                            if (errors.Count == 0)
                            {
                                foreach (var output in outputs)
                                    Console.WriteLine(output);
                            }
                            else
                            {
                                foreach (var error in errors)
                                    Console.WriteLine(error);
                            }
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