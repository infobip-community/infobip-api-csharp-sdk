using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// GetScheduledSmsMessagesRequest
    /// </summary>
    public class GetScheduledSmsMessagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetScheduledSmsMessagesRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetScheduledSmsMessagesRequest() { }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonProperty("bulkId")]
        [Required]
        public string BulkId { get; set; }
    }
}
