using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Sent SMS price.
    /// </summary>
    public class SmsPrice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsPrice" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsPrice() { }

        /// <summary>
        /// The currency in which the price is expressed
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Price per one SMS.
        /// </summary>
        [JsonProperty("pricePerMessage")]
        public double PricePerMessage { get; set; }
    }
}