using System;
using CommandLine;
using amcv;

namespace _360Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Options
    {
        [Option('f', "requestfile", Required = true, HelpText = "Full path of the request-file.")]
        public string RequestFile { get; set; }
        [Option('c', "cmd", Required = true, HelpText = "COmmand to be executed (start, stop, charge).")]
        public string Cmd { get; set; }
    }
}
