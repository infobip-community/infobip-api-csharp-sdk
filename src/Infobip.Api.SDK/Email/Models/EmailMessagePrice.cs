using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// Sent email price.
    /// </summary>
    public class EmailMessagePrice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessagePrice" /> class.
        /// </summary>
        /// <param name="pricePerMessage">Price per one email request.</param>
        /// <param name="currency">The currency in which the price is expressed.</param>
        public EmailMessagePrice(decimal pricePerMessage = default, string currency = default)
        {
            PricePerMessage = pricePerMessage;
            Currency = currency;
        }

        /// <summary>
        /// Price per one email request.
        /// </summary>
        /// <value>Price per one email request.</value>
        [JsonProperty("pricePerMessage")]
        public decimal PricePerMessage { get; set; }

        /// <summary>
        /// The currency in which the price is expressed.
        /// </summary>
        /// <value>The currency in which the price is expressed.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}