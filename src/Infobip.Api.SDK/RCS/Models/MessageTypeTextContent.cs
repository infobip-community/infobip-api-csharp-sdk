using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// MessageTypeTextContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeTextContent : MessageTypeContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeTextContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageTypeTextContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeTextContent" /> class.
        /// </summary>
        /// <param name="text">Message text (required).</param>
        /// <param name="suggestions">List of suggestions.</param>
        public MessageTypeTextContent(string text, List<Suggestion> suggestions = default) : base(MessageTypeContentTypeEnum.Text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Suggestions = suggestions;
        }

        /// <summary>
        /// Message text
        /// </summary>
        /// <value>Message text</value>
        [JsonProperty("text")]
        [StringLength(1000, MinimumLength = 1)]
        public string Text { get; set; }

        /// <summary>
        /// List of suggestions
        /// </summary>
        /// <value>List of suggestions</value>
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
}