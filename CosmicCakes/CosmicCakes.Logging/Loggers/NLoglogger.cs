using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace CosmicCakes.Logging.Loggers
{
    public class NLogLogger : IAppLogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(Exception ex, string message)
        {
            logger.Error(ex, ex.Message, message);
        }
    }
}
