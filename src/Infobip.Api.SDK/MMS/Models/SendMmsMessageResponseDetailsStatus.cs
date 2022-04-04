using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// SendMmsMessageResponseDetailsStatus
    /// </summary>
    public class SendMmsMessageResponseDetailsStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMmsMessageResponseDetailsStatus" /> class.
        /// </summary>
        [JsonConstructor]
        public SendMmsMessageResponseDetailsStatus() { }

        /// <summary>
        /// Status group ID.
        /// </summary>
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Status group name.
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Status ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Status name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Status description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}