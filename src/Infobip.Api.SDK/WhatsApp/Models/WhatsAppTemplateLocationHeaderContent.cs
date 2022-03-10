using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateLocationHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class WhatsAppTemplateLocationHeaderContent : WhatsAppTemplateHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateLocationHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateLocationHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateLocationHeaderContent" /> class.
        /// </summary>
        /// <param name="latitude">Latitude of a location sent in the header. (required).</param>
        /// <param name="longitude">Longitude of a location sent in the header. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppTemplateLocationHeaderContent(double latitude = default, double longitude = default) : base(TypeEnum.Location)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Latitude of a location sent in the header.
        /// </summary>
        /// <value>Latitude of a location sent in the header.</value>
        [JsonProperty("latitude")]
        [Required(ErrorMessage = "Latitude is required")]
        [Range(-90D, 90D)]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of a location sent in the header.
        /// </summary>
        /// <value>Longitude of a location sent in the header.</value>
        [JsonProperty("longitude")]
        [Required(ErrorMessage = "Longitude is required")]
        [Range(-180D, 180D)]
        public double Longitude { get; set; }
    }
}