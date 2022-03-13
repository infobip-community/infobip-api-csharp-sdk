using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Exceptions.Models
{
    public class ServiceException
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("validationErrors")]
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}