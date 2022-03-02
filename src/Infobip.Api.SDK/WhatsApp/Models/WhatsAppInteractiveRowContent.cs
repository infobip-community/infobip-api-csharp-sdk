using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Array of rows sent in the section. Section must contain at least one row. Message can have up to ten rows.
    /// </summary>
    public class WhatsAppInteractiveRowContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveRowContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveRowContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveRowContent" /> class.
        /// </summary>
        /// <param name="id">Identifier of the row. It must be unique across all sections. (required).</param>
        /// <param name="title">Title of the row. (required).</param>
        /// <param name="description">Description of the row..</param>
        public WhatsAppInteractiveRowContent(string id = default, string title = default, string description = default)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description;
        }

        /// <summary>
        /// Identifier of the row. It must be unique across all sections.
        /// </summary>
        /// <value>Identifier of the row. It must be unique across all sections.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Title of the row.
        /// </summary>
        /// <value>Title of the row.</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Description of the row.
        /// </summary>
        /// <value>Description of the row.</value>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Id (string) maxLength
            if (Id != null && Id.Length > 200)
            {
                yield return new ValidationResult("Invalid value for Id, length must be less than 200.", new[] { "Id" });
            }

            // Id (string) minLength
            if (Id != null && Id.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Id, length must be greater than 1.", new[] { "Id" });
            }

            // Title (string) maxLength
            if (Title != null && Title.Length > 24)
            {
                yield return new ValidationResult("Invalid value for Title, length must be less than 24.", new[] { "Title" });
            }

            // Title (string) minLength
            if (Title != null && Title.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Title, length must be greater than 1.", new[] { "Title" });
            }

            // Description (string) maxLength
            if (Description != null && Description.Length > 72)
            {
                yield return new ValidationResult("Invalid value for Description, length must be less than 72.", new[] { "Description" });
            }

            // Description (string) minLength
            if (Description != null && Description.Length < 0)
            {
                yield return new ValidationResult("Invalid value for Description, length must be greater than 0.", new[] { "Description" });
            }

            yield break;
        }
    }
}