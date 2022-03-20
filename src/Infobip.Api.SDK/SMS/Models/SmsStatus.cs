using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Indicates the [status](https://www.infobip.com/docs/essentials/response-status-and-error-codes#api-status-codes) of the message and how to recover from an error should there be any.
    /// </summary>
    public class SmsStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsStatus" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsStatus() { }

        /// <summary>
        /// Action that should be taken to recover from the error.
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// Human-readable description of the status.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Status group ID.
        /// </summary>
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Status group name that describes which category the status code belongs to, e.g. PENDING, UNDELIVERABLE, DELIVERED, EXPIRED, REJECTED.
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Status ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// [Status name](https://www.infobip.com/docs/essentials/response-status-and-error-codes).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}