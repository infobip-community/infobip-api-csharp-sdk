using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// SMS message to be sent if the WhatsApp template message could not be delivered.
    /// </summary>
    public class WhatsAppSmsFailover : IValidatableObject
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
        public string From { get; set; }

        /// <summary>
        /// Content of the SMS that will be sent.
        /// </summary>
        /// <value>Content of the SMS that will be sent.</value>
        [JsonProperty("text")]
        public string Text { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // From (string) maxLength
            if (From != null && From.Length > 24)
            {
                yield return new ValidationResult("Invalid value for From, length must be less than 24.", new[] { "From" });
            }

            // From (string) minLength
            if (From != null && From.Length < 1)
            {
                yield return new ValidationResult("Invalid value for From, length must be greater than 1.", new[] { "From" });
            }

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