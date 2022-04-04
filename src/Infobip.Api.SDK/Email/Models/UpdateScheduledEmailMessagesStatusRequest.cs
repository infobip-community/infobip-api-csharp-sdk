using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// UpdateScheduledEmailMessagesStatusRequest
    /// </summary>
    public class UpdateScheduledEmailMessagesStatusRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateScheduledEmailMessagesStatusRequest" /> class.
        /// </summary>
        [JsonConstructor]
        public UpdateScheduledEmailMessagesStatusRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateScheduledEmailMessagesStatusRequest" /> class.
        /// </summary>
        /// <param name="status">BulkStatusInfo.</param>
        public UpdateScheduledEmailMessagesStatusRequest(BulkStatusInfoEnum status = default)
        {
            Status = status;
        }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty("status")]
        [Required]
        public BulkStatusInfoEnum? Status { get; set; }
    }
}
