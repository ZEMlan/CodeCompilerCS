using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using CompilerDLL;

namespace SharpConsole
{
    class Program
    {
        const string PyExePath = "C:/Python37/python.exe";
        const string PyCodePath = "C:/Python37/input.py";

        static void Main(string[] args)
        {
            Console.Title = "PythonConsole";
            Compiler compiler = new Compiler(PyExePath, PyCodePath);

            List<string> input = new List<string>();
            input.Add("#!/usr/local/bin/python\n# -*- coding: utf-8 -*-\n\n");
            while (true)
            {
                Console.Write("py> ");
                string line = Console.ReadLine();
                switch (line)
                {
                    case "!r":
                        {
                            var code = FormatCode(input);
                            compiler.WriteCode(code);
                            compiler.Execute();
                            Console.WriteLine(compiler.outputs);
                            Console.WriteLine(compiler.errors);
                        }
                        break;

                    default:
                        {
                            input.Add(line);
                        }
                        break;
                }

            }
        }

        static string FormatCode(List<string> lines)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var line in lines)
                builder.Append(line + "\n");
            return builder.ToString();
        }
    }
}