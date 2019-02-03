using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amcv
{
    class CommandModel
    {
        [Flags]
        public enum CommandsFlags
        {
            None = 0,
            StartCleaning = 1,
            StopCleaning = 2,
            ChargeCleaning = 4,
            CookieSet = 8,
            Complete = 15
        }

        [JsonIgnore]
        private string startCleaningCommand = string.Empty;
        [JsonIgnore]
        private string stopCleaningCommand = string.Empty;
        [JsonIgnore]
        private string chargeCleaningCommand = string.Empty;
        [JsonIgnore]
        private string cookie = string.Empty;

        [JsonIgnore]
        private CommandsFlags cmdFlags = CommandsFlags.None;

        [JsonIgnore]
        public CommandsFlags CmdFlags
        {
            get
            {
                return cmdFlags;
            }
            set
            {
                cmdFlags = value;
            }
        }
        
        public string Cookie
        {
            get
            {
                return cookie;
            }
            set
            {
                if (cookie == string.Empty)
                {
                    cookie = value;
                    cmdFlags = cmdFlags | CommandsFlags.CookieSet;
                }
            }
        }

        public string StartCleaningCommand
        {
            get
            {
                return startCleaningCommand;
            }
            set
            {
                if (startCleaningCommand == string.Empty)
                {
                    startCleaningCommand = value;
                    cmdFlags = cmdFlags | CommandsFlags.StartCleaning;
                }
            }
        }

        public string StopCleaningCommand
        {
            get
            {
                return stopCleaningCommand;
            }
            set
            {
                if (stopCleaningCommand == string.Empty)
                {
                    stopCleaningCommand = value;
                    cmdFlags = cmdFlags | CommandsFlags.StopCleaning;
                }
            }
        }

        public string ChargeCleaningCommand
        {
            get
            {
                return chargeCleaningCommand;
            }
            set
            {
                if (chargeCleaningCommand == string.Empty)
                {
                    chargeCleaningCommand = value;
                    cmdFlags = cmdFlags | CommandsFlags.ChargeCleaning;
                }
            }
        }

    }
}
