using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UMS.Business.Helpers;
using UMS.Core.Enums;
using UMS.Core.Exceptions;
using UMS.Dto;

namespace UMS.Api.Helpers
{
    public class ErrorHandlingMiddleware
    {
            private readonly RequestDelegate _next;
            /// <summary>
            /// ctor
            /// </summary>
            public ErrorHandlingMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            /// <summary>
            /// Each request passes this method
            /// </summary>
            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception e)
                {
                    await HandleExceptionAsync(context, e);
                }
            }

            private async Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                var errorCode = ErrorCode.InternalServerError;
                switch (exception)
                {
                    case PermissionDeniedException:
                        errorCode = ErrorCode.PermissionDenied;
                        break;
                    default:
                        break;
                }

                var stream = new StreamReader(context.Request.Body);
                stream.BaseStream.Seek(0, SeekOrigin.Begin);
                var input = await stream.ReadToEndAsync();

                await ErrorLogger.Log(input, exception.Message, exception.StackTrace, exception.InnerException?.Message,
                    exception.InnerException?.StackTrace, context.Request.Path);

                var result = JsonConvert.SerializeObject(Result<object>.CreateErrorResult(errorCode));
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                await context.Response.WriteAsync(result);
            }
    }
}
