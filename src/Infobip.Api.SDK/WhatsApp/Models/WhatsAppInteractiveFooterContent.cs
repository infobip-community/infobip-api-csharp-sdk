using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message footer.
    /// </summary>
    public class WhatsAppInteractiveFooterContent : IValidatableObject
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
        public string Text { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Text (string) maxLength
            if (Text != null && Text.Length > 60)
            {
                yield return new ValidationResult("Invalid value for Text, length must be less than 60.", new[] { "Text" });
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