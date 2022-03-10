using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Array of emails information.
    /// </summary>
    public class WhatsAppEmailContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppEmailContent" /> class.
        /// </summary>
        [JsonConstructor]
        public WhatsAppEmailContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppEmailContent" /> class.
        /// </summary>
        /// <param name="email">Contact&#39;s email..</param>
        /// <param name="type">type.</param>
        public WhatsAppEmailContent(string email = default, WhatsAppEmailType type = WhatsAppEmailType.Home)
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
    }
}