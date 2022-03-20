using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetEmailDeliveryReportsResponse
    /// </summary>
    public class GetEmailDeliveryReportsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailDeliveryReportsResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetEmailDeliveryReportsResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailDeliveryReportsResponse" /> class.
        /// </summary>
        /// <param name="results">results.</param>
        public GetEmailDeliveryReportsResponse(List<EmailMessageReport> results = default)
        {
            Results = results ?? throw new ArgumentNullException(nameof(results));
        }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [JsonProperty("results")]
        public List<EmailMessageReport> Results { get; set; }
    }
}

