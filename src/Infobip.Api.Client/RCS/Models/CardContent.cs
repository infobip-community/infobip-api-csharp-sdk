using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.RCS.Models
{
    /// <summary>
    /// An array of cards contained within the carousel
    /// </summary>
    public class CardContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardContent" /> class.
        /// </summary>
        /// <param name="title">Title of the card, displayed as bolded text.</param>
        /// <param name="description">Description of the card, displayed as regular text.</param>
        /// <param name="media">media.</param>
        /// <param name="suggestions">List of suggestions that will be sent in card.</param>
        public CardContent(string title = default, string description = default, CardMedia media = default, List<Suggestion> suggestions = default)
        {
            Title = title;
            Description = description;
            Media = media;
            Suggestions = suggestions;
        }

        /// <summary>
        /// Title of the card, displayed as bolded text
        /// </summary>
        /// <value>Title of the card, displayed as bolded text</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Description of the card, displayed as regular text
        /// </summary>
        /// <value>Description of the card, displayed as regular text</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Media
        /// </summary>
        [JsonProperty("media")]
        public CardMedia Media { get; set; }

        /// <summary>
        /// List of suggestions that will be sent in card
        /// </summary>
        /// <value>List of suggestions that will be sent in card</value>
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Title (string) maxLength
            if (Title != null && Title.Length > 200)
            {
                yield return new ValidationResult("Invalid value for Title, length must be less than 200.", new[] { "Title" });
            }

            // Title (string) minLength
            if (Title != null && Title.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Title, length must be greater than 1.", new[] { "Title" });
            }

            // Description (string) maxLength
            if (Description != null && Description.Length > 2000)
            {
                yield return new ValidationResult("Invalid value for Description, length must be less than 2000.", new[] { "Description" });
            }

            // Description (string) minLength
            if (Description != null && Description.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Description, length must be greater than 1.", new[] { "Description" });
            }
        }
    }
}