using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// DialPhoneSuggestion
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubType(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubType(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubType(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class DialPhoneSuggestion : Suggestion, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialPhoneSuggestion" /> class.
        /// </summary>
        [JsonConstructor]
        protected DialPhoneSuggestion() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialPhoneSuggestion" /> class.
        /// </summary>
        /// <param name="phoneNumber">Valid phone number.</param>
        /// <param name="text">Suggestion text (required).</param>
        /// <param name="postbackData">Value which is going to be sent as a reply to a suggestion (required).</param>
        public DialPhoneSuggestion(string phoneNumber, string text, string postbackData = default)
            : base(text, postbackData, CardContentSuggestionTypeEnum.DialPhone)
        {
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Valid phone number
        /// </summary>
        /// <value>Valid phone number</value>
        [JsonProperty("phoneNumber")]
        //[RegularExpression(@"\\+?\\d{5,15}", ErrorMessage = "Invalid value for PhoneNumber, must match a pattern of \\+?\\d{5,15}")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // PhoneNumber (string) pattern
            var regex = new Regex(@"^\+?\d{5,15}$", RegexOptions.CultureInvariant);
            if (false == regex.Match(PhoneNumber).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for PhoneNumber, must match a pattern of {regex}", new[] { nameof(PhoneNumber) });
            }
        }
    }
}