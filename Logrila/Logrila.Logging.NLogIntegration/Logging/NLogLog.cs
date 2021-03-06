﻿using System;
using NLog;
using TLogLevel = Logrila.Logging.LogLevel;

namespace Logrila.Logging.NLogIntegration
{
    public class NLogLog : ILog
    {
        private readonly NLog.Logger _logger;

        public NLogLog(NLog.Logger logger, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            _logger = logger;
        }

        public bool IsTraceEnabled
        {
            get { return _logger.IsTraceEnabled; }
        }

        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return _logger.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return _logger.IsWarnEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return _logger.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return _logger.IsFatalEnabled; }
        }

        public void Trace(object obj)
        {
            _logger.Log(NLog.LogLevel.Trace, obj);
        }

        public void Trace(object obj, Exception exception)
        {
            string message = string.Format("{0}{1}{2}", obj == null ? "" : obj.ToString(), Environment.NewLine, ExceptionRender.Parse(exception));
            _logger.Log(NLog.LogLevel.Trace, exception, message);
        }

        public void Trace(LogOutputProvider logOutputProvider)
        {
            _logger.Trace(ToLogMessageGenerator(logOutputProvider));
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Trace, formatProvider, format, args);
        }

        public void TraceFormat(string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Trace, format, args);
        }

        public void Debug(object obj)
        {
            _logger.Log(NLog.LogLevel.Debug, obj);
        }

        public void Debug(object obj, Exception exception)
        {
            string message = string.Format("{0}{1}{2}", obj == null ? "" : obj.ToString(), Environment.NewLine, ExceptionRender.Parse(exception));
            _logger.Log(NLog.LogLevel.Debug, exception, message);
        }

        public void Debug(LogOutputProvider logOutputProvider)
        {
            _logger.Debug(ToLogMessageGenerator(logOutputProvider));
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Debug, formatProvider, format, args);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Debug, format, args);
        }

        public void Info(object obj)
        {
            _logger.Log(NLog.LogLevel.Info, obj);
        }

        public void Info(object obj, Exception exception)
        {
            string message = string.Format("{0}{1}{2}", obj == null ? "" : obj.ToString(), Environment.NewLine, ExceptionRender.Parse(exception));
            _logger.Log(NLog.LogLevel.Info, exception, message);
        }

        public void Info(LogOutputProvider logOutputProvider)
        {
            _logger.Info(ToLogMessageGenerator(logOutputProvider));
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Info, formatProvider, format, args);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Info, format, args);
        }

        public void Warn(object obj)
        {
            _logger.Log(NLog.LogLevel.Warn, obj);
        }

        public void Warn(object obj, Exception exception)
        {
            string message = string.Format("{0}{1}{2}", obj == null ? "" : obj.ToString(), Environment.NewLine, ExceptionRender.Parse(exception));
            _logger.Log(NLog.LogLevel.Warn, exception, message);
        }

        public void Warn(LogOutputProvider logOutputProvider)
        {
            _logger.Warn(ToLogMessageGenerator(logOutputProvider));
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Warn, formatProvider, format, args);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Warn, format, args);
        }

        public void Error(object obj)
        {
            _logger.Log(NLog.LogLevel.Error, obj);
        }

        public void Error(object obj, Exception exception)
        {
            string message = string.Format("{0}{1}{2}", obj == null ? "" : obj.ToString(), Environment.NewLine, ExceptionRender.Parse(exception));
            _logger.Log(NLog.LogLevel.Error, exception, message);
        }

        public void Error(LogOutputProvider logOutputProvider)
        {
            _logger.Error(ToLogMessageGenerator(logOutputProvider));
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Error, formatProvider, format, args);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Error, format, args);
        }

        public void Fatal(object obj)
        {
            _logger.Log(NLog.LogLevel.Fatal, obj);
        }

        public void Fatal(object obj, Exception exception)
        {
            string message = string.Format("{0}{1}{2}", obj == null ? "" : obj.ToString(), Environment.NewLine, ExceptionRender.Parse(exception));
            _logger.Log(NLog.LogLevel.Fatal, exception, message);
        }

        public void Fatal(LogOutputProvider logOutputProvider)
        {
            _logger.Fatal(ToLogMessageGenerator(logOutputProvider));
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Fatal, formatProvider, format, args);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _logger.Log(NLog.LogLevel.Fatal, format, args);
        }

        private void Log(TLogLevel level, object obj)
        {
            _logger.Log(level.ToNLogLogLevel(), obj);
        }

        private void Log(TLogLevel level, object obj, Exception exception)
        {
            string message = string.Format("{0}{1}{2}",
                obj == null ? "" : obj.ToString(), Environment.NewLine, ExceptionRender.Parse(exception));
            _logger.Log(level.ToNLogLogLevel(), exception, message);
        }

        private void Log(TLogLevel level, LogOutputProvider logOutputProvider)
        {
            _logger.Log(level.ToNLogLogLevel(), ToLogMessageGenerator(logOutputProvider));
        }

        private void LogFormat(TLogLevel level, IFormatProvider formatProvider, string format, params object[] args)
        {
            _logger.Log(level.ToNLogLogLevel(), formatProvider, format, args);
        }

        private void LogFormat(TLogLevel level, string format, params object[] args)
        {
            _logger.Log(level.ToNLogLogLevel(), format, args);
        }

        private LogMessageGenerator ToLogMessageGenerator(LogOutputProvider provider)
        {
            return () =>
            {
                object obj = provider();
                return obj == null ? "" : obj.ToString();
            };
        }
    }
}
