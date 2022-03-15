using Newtonsoft.Json;

namespace Infobip.Api.SDK.Exceptions.Models
{
    internal class RequestError
    {
        [JsonProperty("serviceException")]
        public ServiceException ServiceException { get; set; }
    }
}