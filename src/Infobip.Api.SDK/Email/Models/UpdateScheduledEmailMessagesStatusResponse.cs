using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// UpdateScheduledEmailMessagesStatusResponse
    /// </summary>
    public class UpdateScheduledEmailMessagesStatusResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateScheduledEmailMessagesStatusResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public UpdateScheduledEmailMessagesStatusResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateScheduledEmailMessagesStatusResponse" /> class.
        /// </summary>
        /// <param name="bulkId">bulkId.</param>
        /// <param name="status">sendAt.</param>
        public UpdateScheduledEmailMessagesStatusResponse(string bulkId = default, BulkStatusInfoEnum status = default)
        {
            BulkId = bulkId;
            Status = status;
        }

        /// <summary>
        /// Gets or Sets BulkId
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty("Status")]
        public BulkStatusInfoEnum Status { get; set; }
    }
}
