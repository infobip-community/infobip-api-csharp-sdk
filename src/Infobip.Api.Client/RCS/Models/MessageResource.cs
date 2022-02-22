using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.RCS.Models
{
    /// <summary>
    /// Resource object describing the thumbnail of the card
    /// </summary>
    public class MessageResource : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResource" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageResource() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResource" /> class.
        /// </summary>
        /// <param name="url">URL of the given resource (required).</param>
        public MessageResource(string url = default)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// URL of the given resource
        /// </summary>
        /// <value>URL of the given resource</value>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Url (string) maxLength
            if (Url != null && Url.Length > 1000)
            {
                yield return new ValidationResult("Invalid value for Url, length must be less than 1000.", new[] { "Url" });
            }

            // Url (string) minLength
            if (Url != null && Url.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Url, length must be greater than 1.", new[] { "Url" });
            }
        }
    }
}