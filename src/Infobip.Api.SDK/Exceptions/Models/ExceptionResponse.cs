using Newtonsoft.Json;

namespace Infobip.Api.SDK.Exceptions.Models
{
    public class ExceptionResponse
    {
        [JsonProperty("requestError")]
        public RequestError RequestError { get; set; }
    }
}
