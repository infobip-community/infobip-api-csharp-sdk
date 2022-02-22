using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// Array of phones information.
    /// </summary>
    public class WhatsAppPhoneContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppPhoneContent" /> class.
        /// </summary>
        /// <param name="phone">Contact&#39;s phone number..</param>
        /// <param name="type">type.</param>
        /// <param name="waId">Contact&#39;s WhatsApp ID..</param>
        public WhatsAppPhoneContent(string phone = default, WhatsAppPhoneType type = default, string waId = default)
        {
            Phone = phone;
            Type = type;
            WaId = waId;
        }

        /// <summary>
        /// Contact&#39;s phone number.
        /// </summary>
        /// <value>Contact&#39;s phone number.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public WhatsAppPhoneType Type { get; set; }

        /// <summary>
        /// Contact&#39;s WhatsApp ID.
        /// </summary>
        /// <value>Contact&#39;s WhatsApp ID.</value>
        [JsonProperty("waId")]
        public string WaId { get; set; }
        
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