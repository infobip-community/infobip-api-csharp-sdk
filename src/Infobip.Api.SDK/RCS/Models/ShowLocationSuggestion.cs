using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// ShowLocationSuggestion
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubType(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubType(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubType(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class ShowLocationSuggestion : Suggestion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowLocationSuggestion" /> class.
        /// </summary>
        [JsonConstructor]
        protected ShowLocationSuggestion() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowLocationSuggestion" /> class.
        /// </summary>
        /// <param name="latitude">Latitude of the location (required).</param>
        /// <param name="longitude">Longitude of the location (required).</param>
        /// <param name="label">Label of the location.</param>
        /// <param name="text">Suggestion text (required).</param>
        /// <param name="postbackData">Value which is going to be sent as a reply to a suggestion (required).</param>
        public ShowLocationSuggestion(double latitude = default, double longitude = default, string label = default, string text = default, string postbackData = default) 
            : base(text, postbackData, TypeEnum.SHOWLOCATION)
        {
            Latitude = latitude;
            Longitude = longitude;
            Label = label;
        }

        /// <summary>
        /// Latitude of the location
        /// </summary>
        /// <value>Latitude of the location</value>
        [JsonProperty("latitude")]
        [MaxLength(90)]
        [MinLength(-90)]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the location
        /// </summary>
        /// <value>Longitude of the location</value>
        [JsonProperty("longitude")]
        [MaxLength(180)]
        [MinLength(-180)]
        public double Longitude { get; set; }

        /// <summary>
        /// Label of the location
        /// </summary>
        /// <value>Label of the location</value>
        [JsonProperty("label")]
        [StringLength(100, MinimumLength = 1)]
        public string Label { get; set; }
    }
}