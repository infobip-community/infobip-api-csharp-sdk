using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetEmailLogsResponse
    /// </summary>
    public class GetEmailLogsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailLogsResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetEmailLogsResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailLogsResponse" /> class.
        /// </summary>
        /// <param name="results">Array of email logs, one object per each email request..</param>
        public GetEmailLogsResponse(List<EmailLogReport> results = default)
        {
            Results = results;
        }

        /// <summary>
        /// Array of email logs, one object per each email request.
        /// </summary>
        /// <value>Array of email logs, one object per each email request.</value>
        [JsonProperty("results")]
        public List<EmailLogReport> Results { get; set; }
    }
}
