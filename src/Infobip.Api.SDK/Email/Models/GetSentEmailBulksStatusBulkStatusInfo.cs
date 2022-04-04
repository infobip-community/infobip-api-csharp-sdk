using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetSentEmailBulksStatusBulkStatusInfo
    /// </summary>
    public class GetSentEmailBulksStatusBulkStatusInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksStatusResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetSentEmailBulksStatusBulkStatusInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksStatusBulkStatusInfo" /> class.
        /// </summary>
        /// <param name="bulkId">bulkId.</param>
        /// <param name="status">status.</param>
        public GetSentEmailBulksStatusBulkStatusInfo(string bulkId = default, BulkStatusInfoEnum status = default)
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
        [JsonProperty("status")]
        public BulkStatusInfoEnum Status { get; set; }
    }
}