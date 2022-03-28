using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// Sent MMS price.
    /// </summary>
    public class MmsPrice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MmsPrice" /> class.
        /// </summary>
        [JsonConstructor]
        public MmsPrice() { }

        /// <summary>
        /// Price per one MMS.
        /// </summary>
        [JsonProperty("pricePerMessage")]
        public double PricePerMessage { get; set; }

        /// <summary>
        /// The currency in which the price is expressed.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}