using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

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
        public MessageTypeCarouselContent(MessageTypeCarouselContentCardWidthEnum cardWidth, List<CardContent> contents, List<Suggestion> suggestions = default) : base(MessageTypeContentTypeEnum.Carousel)
        {
            CardWidth = cardWidth;
            Contents = contents ?? throw new ArgumentNullException(nameof(contents));
            Suggestions = suggestions;
        }

        /// <summary>
        /// Width of cards contained within the carousel
        /// </summary>
        /// <value>Width of cards contained within the carousel</value>
        [JsonProperty("cardWidth")]
        [Required(ErrorMessage = "CardWidth is required")]
        public MessageTypeCarouselContentCardWidthEnum CardWidth { get; set; }

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