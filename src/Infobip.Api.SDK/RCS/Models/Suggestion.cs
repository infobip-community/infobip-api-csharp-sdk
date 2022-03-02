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
    /// List of suggestions that will be sent in card
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class Suggestion : IValidatableObject
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
        public string Text { get; set; }

        /// <summary>
        /// Value which is going to be sent as a reply to a suggestion
        /// </summary>
        /// <value>Value which is going to be sent as a reply to a suggestion</value>
        [JsonProperty("postbackData")]
        public string PostbackData { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            // Text (string) maxLength
            if (Text != null && Text.Length > 25)
            {
                yield return new ValidationResult("Invalid value for Text, length must be less than 25.", new[] { "Text" });
            }

            // Text (string) minLength
            if (Text != null && Text.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Text, length must be greater than 1.", new[] { "Text" });
            }

            // PostbackData (string) maxLength
            if (PostbackData != null && PostbackData.Length > 2048)
            {
                yield return new ValidationResult("Invalid value for PostbackData, length must be less than 2048.", new[] { "PostbackData" });
            }

            // PostbackData (string) minLength
            if (PostbackData != null && PostbackData.Length < 1)
            {
                yield return new ValidationResult("Invalid value for PostbackData, length must be greater than 1.", new[] { "PostbackData" });
            }
        }
    }
}