using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message action.
    /// </summary>
    public class WhatsAppInteractiveListActionContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListActionContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveListActionContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListActionContent" /> class.
        /// </summary>
        /// <param name="title">Title of the list. Does not allow emojis or markdown. (required).</param>
        /// <param name="sections">Array of sections in the list. (required).</param>
        public WhatsAppInteractiveListActionContent(string title = default, List<WhatsAppInteractiveListSectionContent> sections = default)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Sections = sections ?? throw new ArgumentNullException(nameof(sections));
        }

        /// <summary>
        /// Title of the list. Does not allow emojis or markdown.
        /// </summary>
        /// <value>Title of the list. Does not allow emojis or markdown.</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Array of sections in the list.
        /// </summary>
        /// <value>Array of sections in the list.</value>
        [JsonProperty("sections")]
        public List<WhatsAppInteractiveListSectionContent> Sections { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
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