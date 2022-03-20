using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Indicates whether an error occurred during the query execution.
    /// </summary>
    public class SmsError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsError" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsError() { }

        /// <summary>
        /// Human-readable description of the error.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Error group ID.
        /// </summary>
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Error group name.
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Error ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Error name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tells if the error is permanent.
        /// </summary>
        [JsonProperty("permanent")]
        public bool Permanent { get; set; }
    }
}