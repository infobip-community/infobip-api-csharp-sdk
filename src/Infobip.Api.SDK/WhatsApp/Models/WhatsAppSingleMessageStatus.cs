using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppSingleMessageStatus
    /// </summary>
    public class WhatsAppSingleMessageStatus
    {
        /// <summary>
        /// Status group ID.
        /// </summary>
        /// <value>Status group ID.</value>
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Status group name.
        /// </summary>
        /// <value>Status group name.</value>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Status ID.
        /// </summary>
        /// <value>Status ID.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Status name.
        /// </summary>
        /// <value>Status name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Human-readable description of the status.
        /// </summary>
        /// <value>Human-readable description of the status.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Action that should be taken to eliminate the error.
        /// </summary>
        /// <value>Action that should be taken to eliminate the error.</value>
        [JsonProperty("action")]
        public string Action { get; set; }
    }
}