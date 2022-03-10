using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppTextContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTextContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTextContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTextContent" /> class.
        /// </summary>
        /// <param name="text">Content of the message being sent. (required).</param>
        /// <param name="previewUrl">Allows for URL preview from within the message. If the value is set to &#x60;true&#x60;, the message content is expected to contain a URL starting with &#x60;https://&#x60; or &#x60;http://&#x60;. The default value is &#x60;false&#x60;..</param>
        public WhatsAppTextContent(string text = default, bool previewUrl = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            PreviewUrl = previewUrl;
        }

        /// <summary>
        /// Content of the message being sent.
        /// </summary>
        /// <value>Content of the message being sent.</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Text is required")]
        [MinLength(1)]
        [MaxLength(4096)]
        public string Text { get; set; }

        /// <summary>
        /// Allows for URL preview from within the message. If the value is set to &#x60;true&#x60;, the message content is expected to contain a URL starting with &#x60;https://&#x60; or &#x60;http://&#x60;. The default value is &#x60;false&#x60;.
        /// </summary>
        /// <value>Allows for URL preview from within the message. If the value is set to &#x60;true&#x60;, the message content is expected to contain a URL starting with &#x60;https://&#x60; or &#x60;http://&#x60;. The default value is &#x60;false&#x60;.</value>
        [JsonProperty("previewUrl")]
        public bool PreviewUrl { get; set; }
    }
}