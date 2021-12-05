using System;
using Newtonsoft.Json;

namespace KFU.CinemaOnline.Common
{
    public class ErrorModel
    {
        [JsonProperty(PropertyName = "statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }
    }
}