using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveReplyButtonContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveReplyButtonContent), "REPLY")]
    public class WhatsAppInteractiveReplyButtonContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveReplyButtonContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveReplyButtonContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveReplyButtonContent" /> class.
        /// </summary>
        /// <param name="id">Unique identifier of the button. (required).</param>
        /// <param name="title">Unique title of the button. Doesn&#39;t allow emojis or markdown. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppInteractiveReplyButtonContent(string id = default, string title = default, string type = default) : base()
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        /// <summary>
        /// Unique identifier of the button.
        /// </summary>
        /// <value>Unique identifier of the button.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Unique title of the button. Doesn&#39;t allow emojis or markdown.
        /// </summary>
        /// <value>Unique title of the button. Doesn&#39;t allow emojis or markdown.</value>
        [JsonProperty("title")]
        public string Title { get; set; }
        
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
            // Id (string) maxLength
            if (Id != null && Id.Length > 256)
            {
                yield return new ValidationResult("Invalid value for Id, length must be less than 256.", new[] { "Id" });
            }

            // Id (string) minLength
            if (Id != null && Id.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Id, length must be greater than 1.", new[] { "Id" });
            }

            // Title (string) maxLength
            if (Title != null && Title.Length > 20)
            {
                yield return new ValidationResult("Invalid value for Title, length must be less than 20.", new[] { "Title" });
            }

            // Title (string) minLength
            if (Title != null && Title.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Title, length must be greater than 1.", new[] { "Title" });
            }

            yield break;
        }
    }
}