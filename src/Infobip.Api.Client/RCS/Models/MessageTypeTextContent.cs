using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.RCS.Models
{
    /// <summary>
    /// SendRcsMessageMessageTypeTextContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeTextContent : MessageTypeContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeTextContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageTypeTextContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeTextContent" /> class.
        /// </summary>
        /// <param name="text">Message text (required).</param>
        /// <param name="suggestions">List of suggestions.</param>
        /// <param name="type">Message type, describing type of message which is going to be sent over RCS.</param>
        public MessageTypeTextContent(string text = default, List<Suggestion> suggestions = default, TypeEnum? type = default) : base(type)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Suggestions = suggestions;
        }

        /// <summary>
        /// Message text
        /// </summary>
        /// <value>Message text</value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// List of suggestions
        /// </summary>
        /// <value>List of suggestions</value>
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }

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
            if (Text != null && Text.Length > 1000)
            {
                yield return new ValidationResult("Invalid value for Text, length must be less than 1000.", new[] { "Text" });
            }

            // Text (string) minLength
            if (Text != null && Text.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Text, length must be greater than 1.", new[] { "Text" });
            }
        }
    }
}