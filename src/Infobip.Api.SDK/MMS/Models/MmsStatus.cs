using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// Indicates whether the message is successfully sent, not sent, delivered, not delivered, waiting for delivery or any other possible status.
    /// </summary>
    public class MmsStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MmsStatus" /> class.
        /// </summary>
        [JsonConstructor]
        public MmsStatus() { }

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