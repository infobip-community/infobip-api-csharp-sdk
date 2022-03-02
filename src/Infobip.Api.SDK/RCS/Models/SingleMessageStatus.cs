using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// SingleMessageStatus
    /// </summary>
    public class SingleMessageStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleMessageStatus" /> class.
        /// </summary>
        /// <param name="groupId">Status group ID..</param>
        /// <param name="groupName">Status group name..</param>
        /// <param name="id">Status ID..</param>
        /// <param name="name">Status name..</param>
        /// <param name="description">Human-readable description of the status..</param>
        /// <param name="action">Action that should be taken to eliminate the error..</param>
        public SingleMessageStatus(int groupId = default, string groupName = default, int id = default, string name = default, string description = default, string action = default)
        {
            GroupId = groupId;
            GroupName = groupName;
            Id = id;
            Name = name;
            Description = description;
            Action = action;
        }

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