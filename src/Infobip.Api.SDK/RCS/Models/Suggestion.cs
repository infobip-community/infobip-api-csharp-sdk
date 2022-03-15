using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// List of suggestions that will be sent in card
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubType(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubType(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubType(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class Suggestion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Suggestion" /> class.
        /// </summary>
        [JsonConstructor]
        protected Suggestion() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Suggestion" /> class.
        /// </summary>
        /// <param name="text">Suggestion text (required).</param>
        /// <param name="postbackData">Value which is going to be sent as a reply to a suggestion (required).</param>
        /// <param name="type">type.</param>
        public Suggestion(string text, string postbackData, CardContentSuggestionTypeEnum type)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            PostbackData = postbackData ?? throw new ArgumentNullException(nameof(postbackData));
            Type = type;
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public CardContentSuggestionTypeEnum Type { get; set; }

        /// <summary>
        /// Suggestion text
        /// </summary>
        /// <value>Suggestion text</value>
        [JsonProperty("text")]
        [StringLength(25, MinimumLength = 1)]
        public string Text { get; set; }

        /// <summary>
        /// Value which is going to be sent as a reply to a suggestion
        /// </summary>
        /// <value>Value which is going to be sent as a reply to a suggestion</value>
        [JsonProperty("postbackData")]
        [StringLength(2048, MinimumLength = 1)]
        public string PostbackData { get; set; }
    }
}