using KittyApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyApp
{
    public class LoggerManager : ILoggerManager
    {
        public void LogError(string msg)
        {
            // log errors here
        }

        public void LogInfo(string msg)
        {
            // log info for debugging purposes
        }

        public void LogWarning(string msg)
        {
            // log warnings
        }
    }
}
