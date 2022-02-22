using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateLocationHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class SendWhatsAppTemplateLocationHeaderContent : WhatsAppTemplateHeaderContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendWhatsAppTemplateLocationHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected SendWhatsAppTemplateLocationHeaderContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SendWhatsAppTemplateLocationHeaderContent" /> class.
        /// </summary>
        /// <param name="latitude">Latitude of a location sent in the header. (required).</param>
        /// <param name="longitude">Longitude of a location sent in the header. (required).</param>
        /// <param name="type">type (required).</param>
        public SendWhatsAppTemplateLocationHeaderContent(double latitude = default, double longitude = default, string type = default) : base()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Latitude of a location sent in the header.
        /// </summary>
        /// <value>Latitude of a location sent in the header.</value>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of a location sent in the header.
        /// </summary>
        /// <value>Longitude of a location sent in the header.</value>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        
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

            yield break;
        }
    }
}