using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// Array of urls information.
    /// </summary>
    public class WhatsAppUrlContent : IValidatableObject
    {
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
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public SendWhatsAppUrlType Type { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}