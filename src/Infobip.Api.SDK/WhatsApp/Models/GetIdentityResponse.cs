using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// GetIdentityResponse
    /// </summary>
    public class GetIdentityResponse
    {
        /// <summary>
        /// Identity acknowledge status.
        /// </summary>
        [JsonProperty("acknowledged")]
        public string Acknowledged { get; set; }

        /// <summary>
        /// Identity hash.
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Identity event creation date.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
