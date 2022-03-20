using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Region-specific parameters, often imposed by local laws. Use this, if country or region that you are sending an SMS to requires additional information.
    /// </summary>
    public class SmsRegionalOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsRegionalOptions" /> class.
        /// </summary>
        /// <param name="indiaDlt">Distributed Ledger Technology (DLT) specific parameters required for sending SMS to phone numbers registered in India.</param>
        public SmsRegionalOptions(SmsIndiaDltOptions indiaDlt = default)
        {
            IndiaDlt = indiaDlt;
        }

        /// <summary>
        /// Distributed Ledger Technology (DLT) specific parameters required for sending SMS to phone numbers registered in India.
        /// </summary>
        [JsonProperty("indiaDlt")]
        public SmsIndiaDltOptions IndiaDlt { get; set; }
    }
}