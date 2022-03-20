using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SendSmsMessageResponseDetailsStatus
    /// </summary>
    public class SendSmsMessageResponseDetailsStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsMessageResponseDetailsStatus" /> class.
        /// </summary>
        [JsonConstructor]
        public SendSmsMessageResponseDetailsStatus() { }

        /// <summary>
        /// Action that should be taken to recover from the error.
        /// </summary>
        /// <value>Action that should be taken to recover from the error.</value>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// Human-readable description of the status.
        /// </summary>
        /// <value>Human-readable description of the status.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Status group ID.
        /// </summary>
        /// <value>Status group ID.</value>
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Status group name that describes which category the status code belongs to, e.g. PENDING, UNDELIVERABLE, DELIVERED, EXPIRED, REJECTED.
        /// </summary>
        /// <value>Status group name that describes which category the status code belongs to, e.g. PENDING, UNDELIVERABLE, DELIVERED, EXPIRED, REJECTED.</value>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Status ID.
        /// </summary>
        /// <value>Status ID.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// [Status name](https://www.infobip.com/docs/essentials/response-status-and-error-codes).
        /// </summary>
        /// <value>[Status name](https://www.infobip.com/docs/essentials/response-status-and-error-codes).</value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}