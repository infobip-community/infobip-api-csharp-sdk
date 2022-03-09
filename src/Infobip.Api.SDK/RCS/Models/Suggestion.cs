using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// List of suggestions that will be sent in card
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class Suggestion
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum REPLY for value: REPLY
            /// </summary>
            [EnumMember(Value = "REPLY")]
            REPLY = 1,

            /// <summary>
            /// Enum OPENURL for value: OPEN_URL
            /// </summary>
            [EnumMember(Value = "OPEN_URL")]
            OPENURL = 2,

            /// <summary>
            /// Enum DIALPHONE for value: DIAL_PHONE
            /// </summary>
            [EnumMember(Value = "DIAL_PHONE")]
            DIALPHONE = 3,

            /// <summary>
            /// Enum SHOWLOCATION for value: SHOW_LOCATION
            /// </summary>
            [EnumMember(Value = "SHOW_LOCATION")]
            SHOWLOCATION = 4,

            /// <summary>
            /// Enum REQUESTLOCATION for value: REQUEST_LOCATION
            /// </summary>
            [EnumMember(Value = "REQUEST_LOCATION")]
            REQUESTLOCATION = 5

        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public TypeEnum? Type { get; set; }

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
        public Suggestion(string text = default, string postbackData = default, TypeEnum? type = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            PostbackData = postbackData ?? throw new ArgumentNullException(nameof(postbackData));
            Type = type;
        }

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