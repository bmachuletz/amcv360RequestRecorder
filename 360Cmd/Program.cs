using System;
using System.IO;
using CommandLine;
using Newtonsoft.Json;
using amcv;
using System.Net;

namespace _360Cmd
{
    class Program
    {
        static FileInfo fInfo;

        static void Main(string[] args)
        {
            CommandModel.CommandsFlags cmdFlags = new CommandModel.CommandsFlags();

            Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                if (o.Cmd != string.Empty)
                {
                    switch(o.Cmd.ToLower())
                    {
                        case "start":
                            cmdFlags = CommandModel.CommandsFlags.StartCleaning;
                            break;
                        case "stop":
                            cmdFlags = CommandModel.CommandsFlags.StopCleaning;
                            break;
                        case "charge":
                            cmdFlags = CommandModel.CommandsFlags.ChargeCleaning;
                            break;
                    }
                }
                if(o.RequestFile != string.Empty)
                {
                    fInfo = new FileInfo(o.RequestFile);
                }
            });


            if(fInfo.Exists)
            {
                string cmdString = string.Empty;
                string requestFileText = File.ReadAllText(fInfo.FullName);
                CommandModel requestFileModel = JsonConvert.DeserializeObject<CommandModel>(requestFileText);

                if (cmdFlags == CommandModel.CommandsFlags.StartCleaning) { cmdString = requestFileModel.StartCleaningCommand; }
                if (cmdFlags == CommandModel.CommandsFlags.StopCleaning) { cmdString = requestFileModel.StopCleaningCommand; }
                if (cmdFlags == CommandModel.CommandsFlags.ChargeCleaning) { cmdString = requestFileModel.ChargeCleaningCommand; }

                QihooRequest request = new QihooRequest
                {
                    cookie = requestFileModel.Cookie,
                    body = cmdString
                };

                HttpWebResponse response = new HttpWebResponse();

                WebEngine.Request_q_smart_360_cn(request, out response);
            }
            else
            {
                Console.WriteLine("Request-file not found. Please check path.");
            }
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
