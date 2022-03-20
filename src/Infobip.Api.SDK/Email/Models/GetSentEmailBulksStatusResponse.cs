using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetSentEmailBulksStatusResponse
    /// </summary>
    public class GetSentEmailBulksStatusResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksStatusResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetSentEmailBulksStatusResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksStatusResponse" /> class.
        /// </summary>
        /// <param name="externalBulkId">externalBulkId.</param>
        /// <param name="bulks">bulks.</param>
        public GetSentEmailBulksStatusResponse(string externalBulkId = default, List<GetSentEmailBulksStatusBulkStatusInfo> bulks = default)
        {
            ExternalBulkId = externalBulkId;
            Bulks = bulks;
        }

        /// <summary>
        /// Gets or Sets ExternalBulkId
        /// </summary>
        [JsonProperty("externalBulkId")]
        public string ExternalBulkId { get; set; }

        /// <summary>
        /// Gets or Sets Bulks
        /// </summary>
        [JsonProperty("bulks")]
        public List<GetSentEmailBulksStatusBulkStatusInfo> Bulks { get; set; }
    }
}
