using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// SendFullyFeaturedEmailResponse
    /// </summary>
    public class SendFullyFeaturedEmailResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendFullyFeaturedEmailResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public SendFullyFeaturedEmailResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendFullyFeaturedEmailResponse" /> class.
        /// </summary>
        /// <param name="bulkId">BulkId.</param>
        /// <param name="messages">Messages.</param>
        public SendFullyFeaturedEmailResponse(string bulkId = default, List<SendEmailMessageInfo> messages = default)
        {
            BulkId = bulkId;
            Messages = messages ?? throw new ArgumentNullException(nameof(messages));
        }

        /// <summary>
        /// Gets or Sets BulkId
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Gets or Sets Messages
        /// </summary>
        [JsonProperty("messages")]
        public List<SendEmailMessageInfo> Messages { get; set; }
    }
}
