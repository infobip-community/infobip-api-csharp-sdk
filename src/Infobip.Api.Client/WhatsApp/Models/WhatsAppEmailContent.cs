using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// Array of emails information.
    /// </summary>
    public class WhatsAppEmailContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppEmailContent" /> class.
        /// </summary>
        /// <param name="email">Contact&#39;s email..</param>
        /// <param name="type">type.</param>
        public WhatsAppEmailContent(string email = default, WhatsAppEmailType type = default)
        {
            Email = email;
            Type = type;
        }

        /// <summary>
        /// Contact&#39;s email.
        /// </summary>
        /// <value>Contact&#39;s email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public WhatsAppEmailType Type { get; set; }
        
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