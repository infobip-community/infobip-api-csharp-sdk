using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// Indicates whether the error occurred during the query execution.
    /// </summary>
    public class MmsError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MmsError" /> class.
        /// </summary>
        [JsonConstructor]
        public MmsError() { }
        
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
        /// Human-readable description of the error.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}