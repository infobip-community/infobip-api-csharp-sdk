using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppTextContent : IValidatableObject
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
        public string Text { get; set; }

        /// <summary>
        /// Allows for URL preview from within the message. If the value is set to &#x60;true&#x60;, the message content is expected to contain a URL starting with &#x60;https://&#x60; or &#x60;http://&#x60;. The default value is &#x60;false&#x60;.
        /// </summary>
        /// <value>Allows for URL preview from within the message. If the value is set to &#x60;true&#x60;, the message content is expected to contain a URL starting with &#x60;https://&#x60; or &#x60;http://&#x60;. The default value is &#x60;false&#x60;.</value>
        [JsonProperty("previewUrl")]
        public bool PreviewUrl { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Text (string) maxLength
            if (Text != null && Text.Length > 4096)
            {
                yield return new ValidationResult("Invalid value for Text, length must be less than 4096.", new[] { "Text" });
            }

            // Text (string) minLength
            if (Text != null && Text.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Text, length must be greater than 1.", new[] { "Text" });
            }

            yield break;
        }
    }
}