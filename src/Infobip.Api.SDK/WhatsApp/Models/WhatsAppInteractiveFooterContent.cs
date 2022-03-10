using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message footer.
    /// </summary>
    public class WhatsAppInteractiveFooterContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveFooterContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveFooterContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveFooterContent" /> class.
        /// </summary>
        /// <param name="text">Content of the message footer. (required).</param>
        public WhatsAppInteractiveFooterContent(string text = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Content of the message footer.
        /// </summary>
        /// <value>Content of the message footer.</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Footer Text is required")]
        [MinLength(1)]
        [MaxLength(60)]
        public string Text { get; set; }
    }
}