using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.RCS.Models
{
    /// <summary>
    /// SendRcsMessageDialPhoneSuggestion
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
        /// <param name="type">type.</param>
        public DialPhoneSuggestion(string phoneNumber = default, string text = default, string postbackData = default, TypeEnum? type = default)
        {
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Valid phone number
        /// </summary>
        /// <value>Valid phone number</value>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        
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
        protected new IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            // PhoneNumber (string) pattern
            var regexPhoneNumber = new Regex(@"\\+?\\d{5,15}", RegexOptions.CultureInvariant);
            if (false == regexPhoneNumber.Match(PhoneNumber).Success)
            {
                yield return new ValidationResult("Invalid value for PhoneNumber, must match a pattern of " + regexPhoneNumber, new[] { "PhoneNumber" });
            }
        }
    }
}