using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveMultiProductTextHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveMultiProductTextHeaderContent), "TEXT")]
    public class WhatsAppInteractiveMultiProductTextHeaderContent : WhatsAppInteractiveMultiProductHeaderContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductTextHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveMultiProductTextHeaderContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductTextHeaderContent" /> class.
        /// </summary>
        /// <param name="text">Text of the message header. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppInteractiveMultiProductTextHeaderContent(string text = default, string type = default) : base()
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Text of the message header.
        /// </summary>
        /// <value>Text of the message header.</value>
        [JsonProperty("text")]
        public string Text { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in BaseValidate(validationContext))
            {
                yield return x;
            }
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