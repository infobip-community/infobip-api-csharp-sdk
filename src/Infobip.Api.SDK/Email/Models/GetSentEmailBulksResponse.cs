using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetSentEmailBulksResponse
    /// </summary>
    public class GetSentEmailBulksResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetSentEmailBulksResponse()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSentEmailBulksResponse" /> class.
        /// </summary>
        /// <param name="externalBulkId">externalBulkId.</param>
        /// <param name="bulks">bulks.</param>
        public GetSentEmailBulksResponse(string externalBulkId = default, List<GetSentEmailBulksBulkInfo> bulks = default)
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
        public List<GetSentEmailBulksBulkInfo> Bulks { get; set; }
    }
}
