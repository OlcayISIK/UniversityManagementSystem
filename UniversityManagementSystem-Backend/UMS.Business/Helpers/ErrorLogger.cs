using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
using UMS.Data.EF;
using UMS.Data.Entities;

namespace UMS.Business.Helpers
{
    public static class ErrorLogger
    {
        public static async Task Log(string input, string exceptionMessage, string exceptionStackTrace, string innerExceptionMessage, string innerExceptionStackTrace, string methodName)
        {
            await using var context = new Context(ServiceLocator.AppSettings.DatabaseConnectionString);
            var log = new ErrorLog
            {
                CreatedAt = context.Now,
                Input = input,
                ExceptionMessage = exceptionMessage,
                ExceptionStackTrace = exceptionStackTrace,
                InnerExceptionMessage = innerExceptionMessage,
                InnerExceptionStackTrace = innerExceptionStackTrace,
                MethodName = methodName
            };
            // ReSharper disable once MethodHasAsyncOverload
            context.ErrorLogs.Add(log);
            await context.SaveChangesAsync();
        }
    }
}
