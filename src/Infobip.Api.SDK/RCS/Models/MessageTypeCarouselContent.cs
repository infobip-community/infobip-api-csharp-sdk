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
    /// MessageTypeCarouselContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeCarouselContent : MessageTypeContent
    {
        /// <summary>
        /// Width of cards contained within the carousel
        /// </summary>
        /// <value>Width of cards contained within the carousel</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CardWidthEnum
        {
            /// <summary>
            /// Enum SMALL for value: SMALL
            /// </summary>
            [EnumMember(Value = "SMALL")]
            SMALL = 1,

            /// <summary>
            /// Enum MEDIUM for value: MEDIUM
            /// </summary>
            [EnumMember(Value = "MEDIUM")]
            MEDIUM = 2

        }


        /// <summary>
        /// Width of cards contained within the carousel
        /// </summary>
        /// <value>Width of cards contained within the carousel</value>
        [JsonProperty("cardWidth")]
        [Required(ErrorMessage = "CardWidth is required")]
        public CardWidthEnum CardWidth { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeCarouselContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageTypeCarouselContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeCarouselContent" /> class.
        /// </summary>
        /// <param name="cardWidth">Width of cards contained within the carousel (required).</param>
        /// <param name="contents">An array of cards contained within the carousel (required).</param>
        /// <param name="suggestions">List of suggestions.</param>
        public MessageTypeCarouselContent(CardWidthEnum cardWidth = default, List<CardContent> contents = default, List<Suggestion> suggestions = default) : base(TypeEnum.CAROUSEL)
        {
            CardWidth = cardWidth;
            Contents = contents ?? throw new ArgumentNullException(nameof(contents));
            Suggestions = suggestions;
        }

        /// <summary>
        /// An array of cards contained within the carousel
        /// </summary>
        /// <value>An array of cards contained within the carousel</value>
        [JsonProperty("contents")]
        [Required(ErrorMessage = "Contents is required")]
        public List<CardContent> Contents { get; set; }

        /// <summary>
        /// List of suggestions
        /// </summary>
        /// <value>List of suggestions</value>
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
}