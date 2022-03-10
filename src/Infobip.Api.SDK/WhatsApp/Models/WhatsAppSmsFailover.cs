using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// SMS message to be sent if the WhatsApp template message could not be delivered.
    /// </summary>
    public class WhatsAppSmsFailover
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppSmsFailover" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppSmsFailover() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppSmsFailover" /> class.
        /// </summary>
        /// <param name="from">SMS sender number. Must be in international format. (required).</param>
        /// <param name="text">Content of the SMS that will be sent. (required).</param>
        public WhatsAppSmsFailover(string from = default, string text = default)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// SMS sender number. Must be in international format.
        /// </summary>
        /// <value>SMS sender number. Must be in international format.</value>
        [JsonProperty("from")]
        [Required(ErrorMessage = "From is required")]
        [MinLength(1)]
        [MaxLength(24)]
        public string From { get; set; }

        /// <summary>
        /// Content of the SMS that will be sent.
        /// </summary>
        /// <value>Content of the SMS that will be sent.</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Text is required")]
        [MinLength(1)]
        [MaxLength(4096)]
        public string Text { get; set; }
    }
}