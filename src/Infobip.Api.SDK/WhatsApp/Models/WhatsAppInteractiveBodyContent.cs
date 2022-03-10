using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message body.
    /// </summary>
    public class WhatsAppInteractiveBodyContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveBodyContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveBodyContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveBodyContent" /> class.
        /// </summary>
        /// <param name="text">Content of the message body. (required).</param>
        public WhatsAppInteractiveBodyContent(string text = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Content of the message body.
        /// </summary>
        /// <value>Content of the message body.</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Text is required")]
        [MinLength(1)]
        [MaxLength(1024)]
        public string Text { get; set; }
    }
}