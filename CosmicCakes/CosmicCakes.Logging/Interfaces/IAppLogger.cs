﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.Logging.Interfaces
{
    public interface IAppLogger
    {
        void Debug(string message);
        void Error(Exception ex, string message);
    }
}
