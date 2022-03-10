using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// OpenUrlSuggestion
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubType(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubType(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubType(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class OpenUrlSuggestion : Suggestion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenUrlSuggestion" /> class.
        /// </summary>
        [JsonConstructor]
        protected OpenUrlSuggestion() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenUrlSuggestion" /> class.
        /// </summary>
        /// <param name="url">URL that will be opened on mobile phone when the suggestion is selected (required).</param>
        /// <param name="text">Suggestion text (required).</param>
        /// <param name="postbackData">Value which is going to be sent as a reply to a suggestion (required).</param>
        public OpenUrlSuggestion(string url, string text, string postbackData)
            : base(text, postbackData, CardContentSuggestionTypeEnum.OpenUrl)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// URL that will be opened on mobile phone when the suggestion is selected
        /// </summary>
        /// <value>URL that will be opened on mobile phone when the suggestion is selected</value>
        [JsonProperty("url")]
        [Required]
        public string Url { get; set; }
    }
}