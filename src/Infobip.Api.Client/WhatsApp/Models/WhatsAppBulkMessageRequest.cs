using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// SendWhatsAppBulkMessageRequest
    /// </summary>
    public class WhatsAppBulkMessageRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppBulkMessageRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppBulkMessageRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppBulkMessageRequest" /> class.
        /// </summary>
        /// <param name="messages">An array of messages being sent. (required).</param>
        /// <param name="bulkId">The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address..</param>
        public WhatsAppBulkMessageRequest(List<WhatsAppFailoverMessage> messages = default, string bulkId = default)
        {
            Messages = messages ?? throw new ArgumentNullException(nameof(messages));
            BulkId = bulkId;
        }

        /// <summary>
        /// An array of messages being sent.
        /// </summary>
        /// <value>An array of messages being sent.</value>
        [JsonProperty("messages")]
        public List<WhatsAppFailoverMessage> Messages { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address.
        /// </summary>
        /// <value>The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address.</value>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // BulkId (string) maxLength
            if (BulkId != null && BulkId.Length > 100)
            {
                yield return new ValidationResult("Invalid value for BulkId, length must be less than 100.", new[] { "BulkId" });
            }

            // BulkId (string) minLength
            if (BulkId != null && BulkId.Length < 0)
            {
                yield return new ValidationResult("Invalid value for BulkId, length must be greater than 0.", new[] { "BulkId" });
            }

            yield break;
        }
    }
}