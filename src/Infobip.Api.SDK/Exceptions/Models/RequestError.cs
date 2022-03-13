using Newtonsoft.Json;

namespace Infobip.Api.SDK.Exceptions.Models
{
    public class RequestError
    {
        [JsonProperty("serviceException")]
        public ServiceException ServiceException { get; set; }
    }
}