using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// MessageTypeFileContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeFileContent : MessageTypeContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeFileContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageTypeFileContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeFileContent" /> class.
        /// </summary>
        /// <param name="file">file (required).</param>
        /// <param name="thumbnail">thumbnail (required).</param>
        public MessageTypeFileContent(MessageResource file, MessageResource thumbnail) :base(MessageTypeContentTypeEnum.File)
        {
            File = file ?? throw new ArgumentNullException(nameof(file));
            Thumbnail = thumbnail;
        }

        /// <summary>
        /// Gets or Sets File
        /// </summary>
        [JsonProperty("file")]
        [Required(ErrorMessage = "File is required")]
        public MessageResource File { get; set; }

        /// <summary>
        /// Gets or Sets Thumbnail
        /// </summary>
        [JsonProperty("thumbnail")]
        [Required(ErrorMessage = "Thumbnail is required")]
        public MessageResource Thumbnail { get; set; }
    }
}