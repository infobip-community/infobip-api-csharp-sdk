using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// MessageTypeCardContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeCardContent : MessageTypeContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeCardContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageTypeCardContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeCardContent" /> class.
        /// </summary>
        /// <param name="orientation">Orientation type defines orientation in Card message (required).</param>
        /// <param name="alignment">Alignment type defines alignment in Card message (required).</param>
        /// <param name="content">content (required).</param>
        /// <param name="suggestions">List of suggestions.</param>
        public MessageTypeCardContent(MessageTypeCardContentOrientationEnum orientation, MessageTypeCardContentAlignmentEnum alignment, CardContent content, List<Suggestion> suggestions = default) : base(MessageTypeContentTypeEnum.Card)
        {
            Orientation = orientation;
            Alignment = alignment;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Suggestions = suggestions;
        }

        /// <summary>
        /// Orientation type defines orientation in Card message
        /// </summary>
        /// <value>Orientation type defines orientation in Card message</value>
        [JsonProperty("orientation")]
        [Required(ErrorMessage = "Orientation is required")]
        public MessageTypeCardContentOrientationEnum Orientation { get; set; }


        /// <summary>
        /// Alignment type defines alignment in Card message
        /// </summary>
        /// <value>Alignment type defines alignment in Card message</value>
        [JsonProperty("alignment")]
        [Required(ErrorMessage = "Alignment is required")]
        public MessageTypeCardContentAlignmentEnum Alignment { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [JsonProperty("content")]
        [Required(ErrorMessage = "Content is required")]
        public CardContent Content { get; set; }

        /// <summary>
        /// List of suggestions
        /// </summary>
        /// <value>List of suggestions</value>
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
}