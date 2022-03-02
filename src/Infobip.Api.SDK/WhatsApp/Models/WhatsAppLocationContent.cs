using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppLocationContent : IValidatableObject
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
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of a location sent in the WhatsApp message.
        /// </summary>
        /// <value>Longitude of a location sent in the WhatsApp message.</value>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Location name.
        /// </summary>
        /// <value>Location name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Location address.
        /// </summary>
        /// <value>Location address.</value>
        [JsonProperty("address")]
        public string Address { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
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

            // Name (string) maxLength
            if (Name != null && Name.Length > 1000)
            {
                yield return new ValidationResult("Invalid value for Name, length must be less than 1000.", new[] { "Name" });
            }

            // Name (string) minLength
            if (Name != null && Name.Length < 0)
            {
                yield return new ValidationResult("Invalid value for Name, length must be greater than 0.", new[] { "Name" });
            }

            // Address (string) maxLength
            if (Address != null && Address.Length > 1000)
            {
                yield return new ValidationResult("Invalid value for Address, length must be less than 1000.", new[] { "Address" });
            }

            // Address (string) minLength
            if (Address != null && Address.Length < 0)
            {
                yield return new ValidationResult("Invalid value for Address, length must be greater than 0.", new[] { "Address" });
            }

            yield break;
        }
    }
}