using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using NewsWebsite.Common.Api;
using NewsWebsite.IocConfig.Api.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NewsWebsite.IocConfig.Api.Middlewares
{
    public static class CustomExceptionHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _evn;
        public CustomExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment evn)
        {
            _next = next;
            _evn = evn;
        }

        public async Task Invoke(HttpContext context)
        {
            List<string> Message = new List<string>();
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            ApiResultStatusCode apiResultStatus = ApiResultStatusCode.ServerError;

            try
            {
                await _next(context);
            }

            catch (AppException exception)
            {
                httpStatusCode = exception.HttpStatusCode;
                apiResultStatus = exception.ApiStatusCode;

                if (_evn.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    if (exception.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", exception.InnerException.Message);
                        dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                    }
                    if (exception.AdditionalData != null)
                        dic.Add("AdditionalData", JsonConvert.SerializeObject(exception.AdditionalData));

                    Message.Add(JsonConvert.SerializeObject(dic));
                }
                else
                {
                    Message.Add("خطایی رخ داده است.");
                }
                await WriteToResponseAsync();

            }

            catch (Exception exception)
            {
                if(_evn.IsDevelopment())
                {
                    var error = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    Message.Add(JsonConvert.SerializeObject(error));
                }

                else
                {
                    Message.Add("خطایی رخ داده است.");
                }

                await WriteToResponseAsync();
            }

            async Task WriteToResponseAsync()
            {
                var result = new ApiResult(false, apiResultStatus, Message);
                var jsonResult = JsonConvert.SerializeObject(result);

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResult);
            }
        }
    }
}
