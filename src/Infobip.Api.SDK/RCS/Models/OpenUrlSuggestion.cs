using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// SendRcsMessageOpenUrlSuggestion
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubType(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubType(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubType(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class OpenUrlSuggestion : Suggestion, IValidatableObject
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
        /// <param name="type">type.</param>
        public OpenUrlSuggestion(string url = default, string text = default, string postbackData = default, TypeEnum? type = default) : base()
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// URL that will be opened on mobile phone when the suggestion is selected
        /// </summary>
        /// <value>URL that will be opened on mobile phone when the suggestion is selected</value>
        [JsonProperty("url")]
        public string Url { get; set; }

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
            foreach (var x in BaseValidate(validationContext))
            {
                yield return x;
            }
        }
    }
}