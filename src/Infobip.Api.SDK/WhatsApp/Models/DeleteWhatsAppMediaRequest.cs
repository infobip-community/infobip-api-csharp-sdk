using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// DeleteWhatsAppMediaRequest
    /// </summary>
    public class DeleteWhatsAppMediaRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhatsAppMediaRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected DeleteWhatsAppMediaRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhatsAppMediaRequest" /> class.
        /// </summary>
        /// <param name="url">URL of the WhatsApp media to be deleted. (required).</param>
        public DeleteWhatsAppMediaRequest(string url = default)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// URL of the WhatsApp media to be deleted.
        /// </summary>
        /// <value>URL of the WhatsApp media to be deleted.</value>
        [JsonProperty("url")]
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}