using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// GetMmsDeliveryReportResponse
    /// </summary>
    public class GetMmsDeliveryReportResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMmsDeliveryReportResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetMmsDeliveryReportResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMmsDeliveryReportResponse" /> class.
        /// </summary>
        /// <param name="results"><see cref="MmsDeliveryReport"/> results list.</param>
        public GetMmsDeliveryReportResponse(List<MmsDeliveryReport> results = default)
        {
            Results = results;
        }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [JsonProperty("results")]
        public List<MmsDeliveryReport> Results { get; set; }
    }
}