using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// SendWhatsAppBulkMessageRequest
    /// </summary>
    public class WhatsAppBulkMessageRequest
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
        [Required(ErrorMessage = "Messages are required")]
        public List<WhatsAppFailoverMessage> Messages { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address.
        /// </summary>
        /// <value>The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address.</value>
        [JsonProperty("bulkId")]
        [Required(ErrorMessage = "BulkId is required")]
        [MinLength(0)]
        [MaxLength(100)]
        public string BulkId { get; set; }
    }
}