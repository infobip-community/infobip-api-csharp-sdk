using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Array of urls information.
    /// </summary>
    public class WhatsAppUrlContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppUrlContent" /> class.
        /// </summary>
        [JsonConstructor]
        public WhatsAppUrlContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppUrlContent" /> class.
        /// </summary>
        /// <param name="url">Contact&#39;s url..</param>
        /// <param name="type">type.</param>
        public WhatsAppUrlContent(string url = default, SendWhatsAppUrlType type = default)
        {
            Url = url;
            Type = type;
        }

        /// <summary>
        /// Contact&#39;s url.
        /// </summary>
        /// <value>Contact&#39;s url.</value>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets url Type
        /// </summary>
        [JsonProperty("type")]
        public SendWhatsAppUrlType Type { get; set; }
    }
}