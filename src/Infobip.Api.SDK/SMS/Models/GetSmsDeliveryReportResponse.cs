using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsDeliveryReportResponse
    /// </summary>
    public class GetSmsDeliveryReportResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSmsDeliveryReportResponse" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetSmsDeliveryReportResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSmsDeliveryReportResponse" /> class.
        /// </summary>
        /// <param name="results">results.</param>
        public GetSmsDeliveryReportResponse(List<SmsDeliveryReport> results = default)
        {
            Results = results;
        }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [JsonProperty("results")]
        public List<SmsDeliveryReport> Results { get; set; }
    }
}
