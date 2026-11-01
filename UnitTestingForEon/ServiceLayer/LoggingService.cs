using Microsoft.Extensions.Logging;
using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnitTestingForEon.Database;

namespace UnitTestingForEon.ServiceLayer
{
    public class LoggingService<T>(ILogger<T> logger)
    {
        public bool LogDebug(
                            string message,
                            [CallerMemberName] string memberName = "",
                            [CallerFilePath] string fulllPathAndFileName = "",
                            [CallerLineNumber] int lineNumber = 0)
        {
            using (logger.BeginScope(new Dictionary<string, object>
            {
                ["FunctionName"] = memberName,
                ["LineNumber"] = lineNumber,
                ["FileName"] = Path.GetFileName(fulllPathAndFileName)
            })
                )
            {
                logger.LogDebug(message);
            }
            return true;
        }
        public bool LogInformation(
                            string message,
                            [CallerMemberName] string memberName = "",
                            [CallerFilePath] string fulllPathAndFileName = "",
                            [CallerLineNumber] int lineNumber = 0)
        {
            using (logger.BeginScope(new Dictionary<string, object>
            {
                ["FunctionName"] = memberName,
                ["LineNumber"] = lineNumber,
                ["FileName"] = Path.GetFileName(fulllPathAndFileName)
            })
                )
            {
                logger.LogInformation(message);
            }
            return true;
        }
        public bool LogError(
                            Exception ex,
                            string message,
                            [CallerMemberName] string memberName = "",
                            [CallerFilePath] string fulllPathAndFileName = "",
                            [CallerLineNumber] int lineNumber = 0)
        {
            using (logger.BeginScope(new Dictionary<string, object>
            {
                ["FunctionName"] = memberName,
                ["LineNumber"] = lineNumber,
                ["FileName"] = Path.GetFileName(fulllPathAndFileName)
            })
                )
            {
                logger.LogError(ex, message);
            }
            return true;
        }



        public void ChangeDatabaseConnection(IDatabaseConnection newConnection)
        {
            var config = LogManager.Configuration ?? throw new NoNullAllowedException();

            var dbTarget = config.FindTargetByName<DatabaseTarget>("db") ?? throw new NoNullAllowedException(); 

            dbTarget.ConnectionString =
                IDatabaseConnection.ConnectionString;

            LogManager.ReconfigExistingLoggers();
        }
    }
}
