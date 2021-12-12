using System.Net;
using System.Net.Http;
using Microsoft.Rest;

namespace KFU.CinemaOnline.Common
{
    public static class ErrorResponse
    {
        public static void GenerateError(HttpStatusCode statusCode, string message)
        {
            throw new HttpOperationException()
            {
                Response = new HttpResponseMessageWrapper(new HttpResponseMessage(statusCode), message)
                    {Content = message}
            };        
        }
    }
}