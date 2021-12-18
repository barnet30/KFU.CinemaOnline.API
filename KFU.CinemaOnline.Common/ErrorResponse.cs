using System;
using System.Net;
using System.Net.Http;
using Microsoft.Rest;

namespace KFU.CinemaOnline.Common
{
    public static class ErrorResponse
    {
        public static ErrorModel GenerateError(HttpStatusCode statusCode, string message) => 
            new ErrorModel
            {
                Error = statusCode.ToString(),
                StatusCode = (int)statusCode,
                Message = message,
                Time = DateTime.Now
            };
    }
}