using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface ILogger
    {
        void SetLogInfo(string userName, string source = null, string request = null);

        void Log(LogLevel level, string message, string source = null, string request = null);

        void LogDebug(string message, string source = null, string request = null);

        void LogInformation(string message, string source = null, string request = null);

        void LogError(string message, string source = null, string request = null);

        void Log(Exception ex, string source = null, string request = null);
    }
}
