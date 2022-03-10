using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppLocationContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppLocationContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppLocationContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppLocationContent" /> class.
        /// </summary>
        /// <param name="latitude">Latitude of a location sent in the WhatsApp message. (required).</param>
        /// <param name="longitude">Longitude of a location sent in the WhatsApp message. (required).</param>
        /// <param name="name">Location name..</param>
        /// <param name="address">Location address..</param>
        public WhatsAppLocationContent(double latitude = default, double longitude = default, string name = default, string address = default)
        {
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
            Address = address;
        }

        /// <summary>
        /// Latitude of a location sent in the WhatsApp message.
        /// </summary>
        /// <value>Latitude of a location sent in the WhatsApp message.</value>
        [JsonProperty("latitude")]
        [Required(ErrorMessage = "Latitude is required")]
        [Range(-90D, 90D)]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of a location sent in the WhatsApp message.
        /// </summary>
        /// <value>Longitude of a location sent in the WhatsApp message.</value>
        [JsonProperty("longitude")]
        [Required(ErrorMessage = "Longitude is required")]
        [Range(-180D, 180D)]
        public double Longitude { get; set; }

        /// <summary>
        /// Location name.
        /// </summary>
        /// <value>Location name.</value>
        [JsonProperty("name")]
        [MinLength(0)]
        [MaxLength(1000)]
        public string Name { get; set; }

        /// <summary>
        /// Location address.
        /// </summary>
        /// <value>Location address.</value>
        [JsonProperty("address")]
        [MinLength(0)]
        [MaxLength(1000)]
        public string Address { get; set; }
    }
}