using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// Message body.
    /// </summary>
    public class WhatsAppInteractiveBodyContent : IValidatableObject
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
        public string Text { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Text (string) maxLength
            if (Text != null && Text.Length > 1024)
            {
                yield return new ValidationResult("Invalid value for Text, length must be less than 1024.", new[] { "Text" });
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