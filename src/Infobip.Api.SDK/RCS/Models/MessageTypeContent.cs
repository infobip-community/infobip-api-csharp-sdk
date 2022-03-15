using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Rcs message contents
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeContent" /> class.
        /// </summary>
        [JsonConstructor]

        protected MessageTypeContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeContent" /> class.
        /// </summary>
        /// <param name="type">Message type, describing type of message which is going to be sent over RCS.</param>
        public MessageTypeContent(MessageTypeContentTypeEnum type = default)
        {
            Type = type;
        }

        /// <summary>
        /// Message type, describing type of message which is going to be sent over RCS
        /// </summary>
        /// <value>Message type, describing type of message which is going to be sent over RCS</value>
        [JsonProperty("type")]
        [Required(ErrorMessage = "Type is required")]
        public MessageTypeContentTypeEnum Type { get; set; }
    }
}