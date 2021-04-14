using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public enum LogLevel
    {
        Debug = 1,
        Information = 2,
        Error = 4
    }

    public class ErrorLog
    {
        public int Id { get; set; }

        private DateTime _logdate_utc;
        public DateTime LogDate_UTC
        {
            get => _logdate_utc;
            set
            {
                if (value.Kind == DateTimeKind.Unspecified)
                    _logdate_utc = DateTime.SpecifyKind(value, DateTimeKind.Utc);
                else
                    _logdate_utc = value;
            }
        }
         
        public string UserName { get; set; } 
        public string Source { get; set; } 
        public string Request { get; set; }

        public string Message { get; set; }
    }

    /// <summary>
    /// Base logger class, we sepparate this so that we can create multiple implementation of the logging and register the logging structure in the DI    
    /// the logger class will be singleton but the UserName, RequestInfo value will be per thread/request.
    /// </summary>
    public abstract class BaseLogger : ILogger
    {
        private int _logLevel = 4;

        [ThreadStatic]  //since the .net 4.5 and Unity DI can't configure PerRequest instance, we use ThreadStatic as a replacement
        public string UserName;
        [ThreadStatic]
        public string Request;

        public string Source;

        protected readonly BaseLogger successor;

        public BaseLogger(int logLevel = 4, string source = null)
        {
            this._logLevel = logLevel;
            this.Source = source;
        }

        public BaseLogger(BaseLogger successor, int logLevel = 4, string source = null)
        {
            this.successor = successor;
            this._logLevel = logLevel;
            this.Source = source;
        }

        public void SetLogInfo(string userName, string source = null, string request = null)
        {
            this.UserName = userName;
            this.Request = request;
            this.Source = source;
        }

        public virtual void LogDebug(string message, string source = null, string request = null)
        {
            Log(LogLevel.Debug, message, source, request);
        }

        public virtual void LogInformation(string message, string source = null, string request = null)
        {
            Log(LogLevel.Information, message, source, request);
        }

        public virtual void LogError(string message, string source = null, string request = null)
        {
            Log(LogLevel.Error, message, source, request);
        }

        public virtual void Log(Exception ex, string source = null, string request = null)
        {
            LogError(ex.ToString(), source ?? ex.Source, request ?? ex.TargetSite.ToString());
        }

        public virtual void Log(LogLevel level, string message, string source = null, string request = null)
        {
            var _log = new ErrorLog()
            {
                LogDate_UTC = System.DateTime.UtcNow,
                Source = source ?? this.Source,
                Message = message,
                UserName = this.UserName,
                Request = request ?? this.Request
            };

            if ((int)level >= this._logLevel)
                Log(_log);
        }


        protected virtual void Log(ErrorLog log)
        {
            try
            {
                this.DoLogging(log);
            }
            catch//(Exception ex) //oops error, lets use our backup logger
            {
                if (successor != null)
                    successor.Log(log);
            }
        }

        protected abstract void DoLogging(ErrorLog log);
    }
    
    public sealed class EventViewerLogger : BaseLogger, ILogger
    {
        public EventViewerLogger(int logLevel = 4, string source = null) : base(logLevel, source) { }
        public EventViewerLogger(BaseLogger successor, int logLevel = 4, string source = null) : base(successor, logLevel, source) { }

        protected override void DoLogging(ErrorLog log)
        {
            string eventSourceName = "PortfolioTrackerApp";
            if (!System.Diagnostics.EventLog.SourceExists(eventSourceName))
            {
                System.Diagnostics.EventLog.CreateEventSource(eventSourceName, "Application");
            }

            var evLog = new System.Diagnostics.EventLog();
            if (evLog != null)
            {
                evLog.Source = eventSourceName;
                evLog.WriteEntry(log.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            else
                throw new Exception("Error Unable to write to Event Log");
        }
    }
}
