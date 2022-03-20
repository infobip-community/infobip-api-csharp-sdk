using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetSentEmailBulksBulkInfo
    /// </summary>
    public class GetSentEmailBulksBulkInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksBulkInfo" /> class.
        /// </summary>
        [JsonConstructor]
        public GetSentEmailBulksBulkInfo()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksBulkInfo" /> class.
        /// </summary>
        /// <param name="bulkId">bulkId.</param>
        /// <param name="sendAt">sendAt.</param>
        public GetSentEmailBulksBulkInfo(string bulkId = default, DateTime sendAt = default)
        {
            BulkId = bulkId;
            SendAt = sendAt;
        }

        /// <summary>
        /// Gets or Sets BulkId
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Gets or Sets SendAt
        /// </summary>
        [JsonProperty("sendAt")]
        public DateTime SendAt { get; set; }
    }
}