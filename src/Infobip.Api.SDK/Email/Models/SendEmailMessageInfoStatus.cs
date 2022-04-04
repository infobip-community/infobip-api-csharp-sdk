using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// SendEmailMessageInfoStatus
    /// </summary>
    public class SendEmailMessageInfoStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailMessageInfoStatus" /> class.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="description">Description.</param>
        /// <param name="groupId">GroupId.</param>
        /// <param name="groupName">GroupName.</param>
        /// <param name="id">Id.</param>
        /// <param name="name">Name.</param>
        public SendEmailMessageInfoStatus(string action = default, string description = default, int groupId = default, string groupName = default, int id = default, string name = default)
        {
            Action = action;
            Description = description;
            GroupId = groupId;
            GroupName = groupName;
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

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
    }
}