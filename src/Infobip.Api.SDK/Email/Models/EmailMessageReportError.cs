using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// Send email message report error
    /// </summary>
    public class EmailMessageReportError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessageReportError" /> class.
        /// </summary>
        /// <param name="groupId">Status group ID.</param>
        /// <param name="groupName">Status group name.</param>
        /// <param name="id">Status ID.</param>
        /// <param name="name">Status name.</param>
        /// <param name="description">Human-readable description of the status.</param>
        /// <param name="permanent">permanent.</param>
        public EmailMessageReportError(int groupId = default, string groupName = default, int id = default, string name = default, string description = default, bool permanent = default)
        {
            GroupId = groupId;
            GroupName = groupName;
            Id = id;
            Name = name;
            Description = description;
            Permanent = permanent;
        }

        /// <summary>
        /// Gets or Sets GroupId
        /// </summary>
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Gets or Sets GroupName
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Permanent
        /// </summary>
        [JsonProperty("permanent")]
        public bool Permanent { get; set; }
    }
}