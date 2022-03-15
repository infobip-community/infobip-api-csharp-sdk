using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// RequestLocationSuggestion
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubType(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubType(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubType(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class RequestLocationSuggestion : Suggestion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestLocationSuggestion" /> class.
        /// </summary>
        [JsonConstructor]
        protected RequestLocationSuggestion() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestLocationSuggestion" /> class.
        /// </summary>
        /// <param name="text">Suggestion text (required).</param>
        /// <param name="postbackData">Value which is going to be sent as a reply to a suggestion (required).</param>
        public RequestLocationSuggestion(string text = default, string postbackData = default)
            : base(text, postbackData, CardContentSuggestionTypeEnum.RequestLocation)
        {
        }
    }
}