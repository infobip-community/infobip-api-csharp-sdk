using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        /// Orientation type defines orientation in Card message
        /// </summary>
        /// <value>Orientation type defines orientation in Card message</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrientationEnum
        {
            /// <summary>
            /// Enum HORIZONTAL for value: HORIZONTAL
            /// </summary>
            [EnumMember(Value = "HORIZONTAL")]
            HORIZONTAL = 1,

            /// <summary>
            /// Enum VERTICAL for value: VERTICAL
            /// </summary>
            [EnumMember(Value = "VERTICAL")]
            VERTICAL = 2

        }


        /// <summary>
        /// Orientation type defines orientation in Card message
        /// </summary>
        /// <value>Orientation type defines orientation in Card message</value>
        [JsonProperty("orientation")]
        [Required(ErrorMessage = "Orientation is required")]
        public OrientationEnum Orientation { get; set; }

        /// <summary>
        /// Alignment type defines alignment in Card message
        /// </summary>
        /// <value>Alignment type defines alignment in Card message</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AlignmentEnum
        {
            /// <summary>
            /// Enum LEFT for value: LEFT
            /// </summary>
            [EnumMember(Value = "LEFT")]
            LEFT = 1,

            /// <summary>
            /// Enum RIGHT for value: RIGHT
            /// </summary>
            [EnumMember(Value = "RIGHT")]
            RIGHT = 2

        }


        /// <summary>
        /// Alignment type defines alignment in Card message
        /// </summary>
        /// <value>Alignment type defines alignment in Card message</value>
        [JsonProperty("alignment")]
        [Required(ErrorMessage = "Alignment is required")]
        public AlignmentEnum Alignment { get; set; }

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
        public MessageTypeCardContent(OrientationEnum orientation = default, AlignmentEnum alignment = default, CardContent content = default, List<Suggestion> suggestions = default) : base(TypeEnum.CARD)
        {
            Orientation = orientation;
            Alignment = alignment;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Suggestions = suggestions;
        }

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