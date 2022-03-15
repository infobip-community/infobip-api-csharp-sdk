using Newtonsoft.Json;

namespace Infobip.Api.SDK.Exceptions.Models
{
    internal class ExceptionResponse
    {
        [JsonProperty("requestError")]
        internal RequestError RequestError { get; set; }
    }
}
