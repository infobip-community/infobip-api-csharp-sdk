using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// UpdateScheduledSmsMessagesStatusRequest
    /// </summary>
    public class UpdateScheduledSmsMessagesStatusRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateScheduledSmsMessagesStatusRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected UpdateScheduledSmsMessagesStatusRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RescheduleSmsMessagesRequest" /> class.
        /// </summary>
        /// <param name="bulkId">Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.</param>
        /// <param name="status">The status of the message(s).</param>
        public UpdateScheduledSmsMessagesStatusRequest(string bulkId = default, SmsBulkStatus? status = default)
        {
            BulkId = bulkId ?? throw new ArgumentNullException(nameof(bulkId));
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonIgnore]
        [Required]
        public string BulkId { get; set; }

        /// <summary>
        /// The status of the message(s).
        /// </summary>
        [JsonProperty("status")]
        [Required]
        public SmsBulkStatus Status { get; set; }
    }
}
