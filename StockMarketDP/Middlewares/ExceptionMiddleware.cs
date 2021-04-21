using Microsoft.AspNetCore.Http;
using StockMarketDP.DTOs;
using StockMarketDP.Exeptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StockMarketDP.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusException exception)
        {
            ErrorDetailDTO result = null;
            context.Response.ContentType = "application/json";
            if (exception is HttpStatusException)
            {
                result = new ErrorDetailDTO()
                {
                    Message = exception.Message,
                    StatusCode = (int)exception.Status
                };
                context.Response.StatusCode = (int)exception.Status;
            }
            else
            {
                result = new ErrorDetailDTO()
                {
                    Message = "Runtime Error",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsJsonAsync(result); 
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ErrorDetailDTO result = new ErrorDetailDTO()
            {
                Message = exception.Message,
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
