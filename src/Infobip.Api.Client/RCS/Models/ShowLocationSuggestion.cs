using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.RCS.Models
{
    /// <summary>
    /// SendRcsMessageShowLocationSuggestion
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(DialPhoneSuggestion), "DIAL_PHONE")]
    [JsonSubtypes.KnownSubType(typeof(OpenUrlSuggestion), "OPEN_URL")]
    [JsonSubtypes.KnownSubType(typeof(ReplySuggestion), "REPLY")]
    [JsonSubtypes.KnownSubType(typeof(RequestLocationSuggestion), "REQUEST_LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(ShowLocationSuggestion), "SHOW_LOCATION")]
    public class ShowLocationSuggestion : Suggestion, IValidatableObject
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
        /// <param name="type">type.</param>
        public ShowLocationSuggestion(double latitude = default, double longitude = default, string label = default, string text = default, string postbackData = default, TypeEnum? type = default) : base()
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
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the location
        /// </summary>
        /// <value>Longitude of the location</value>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Label of the location
        /// </summary>
        /// <value>Label of the location</value>
        [JsonProperty("label")]
        public string Label { get; set; }

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
            // Latitude (double) maximum
            if (Latitude > (double)90)
            {
                yield return new ValidationResult("Invalid value for Latitude, must be a value less than or equal to 90.", new[] { "Latitude" });
            }

            // Latitude (double) minimum
            if (Latitude < (double)-90)
            {
                yield return new ValidationResult("Invalid value for Latitude, must be a value greater than or equal to -90.", new[] { "Latitude" });
            }

            // Longitude (double) maximum
            if (Longitude > (double)180)
            {
                yield return new ValidationResult("Invalid value for Longitude, must be a value less than or equal to 180.", new[] { "Longitude" });
            }

            // Longitude (double) minimum
            if (Longitude < (double)-180)
            {
                yield return new ValidationResult("Invalid value for Longitude, must be a value greater than or equal to -180.", new[] { "Longitude" });
            }

            // Label (string) maxLength
            if (Label != null && Label.Length > 100)
            {
                yield return new ValidationResult("Invalid value for Label, length must be less than 100.", new[] { "Label" });
            }

            // Label (string) minLength
            if (Label != null && Label.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Label, length must be greater than 1.", new[] { "Label" });
            }
        }
    }
}