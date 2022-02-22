using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// Array of addresses information.
    /// </summary>
    public class WhatsAppAddressContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppAddressContent" /> class.
        /// </summary>
        /// <param name="street">Street name..</param>
        /// <param name="city">City name..</param>
        /// <param name="state">State name..</param>
        /// <param name="zip">Zip code value..</param>
        /// <param name="country">Country name..</param>
        /// <param name="countryCode">Country code value..</param>
        /// <param name="type">type.</param>
        public WhatsAppAddressContent(string street = default, string city = default, string state = default, string zip = default, string country = default, string countryCode = default, WhatsAppAddressType type = default)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            CountryCode = countryCode;
            Type = type;
        }

        /// <summary>
        /// Street name.
        /// </summary>
        /// <value>Street name.</value>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <value>City name.</value>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// State name.
        /// </summary>
        /// <value>State name.</value>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Zip code value.
        /// </summary>
        /// <value>Zip code value.</value>
        [JsonProperty("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <value>Country name.</value>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Country code value.
        /// </summary>
        /// <value>Country code value.</value>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public WhatsAppAddressType Type { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}