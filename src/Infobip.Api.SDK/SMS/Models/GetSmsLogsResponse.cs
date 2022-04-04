using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// GetSmsLogsResponse
    /// </summary>
    public class GetSmsLogsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSmsLogsResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetSmsLogsResponse() { }

        /// <summary>
        /// Collection of logs.
        /// </summary>
        [JsonProperty("results")]
        public List<SmsLog> Results { get; set; }
    }
}
