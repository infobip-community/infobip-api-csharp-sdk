using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// SendMmsMessageResponse
    /// </summary>
    public class SendMmsMessageResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMmsMessageResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public SendMmsMessageResponse() { }

        /// <summary>
        /// Unique bulk identifier.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Array of sent message objects, one object per every message.
        /// </summary>
        [JsonProperty("messages")]
        public List<SendMmsMessageResponseDetails> Messages { get; set; }

        /// <summary>
        /// General error description
        /// </summary>
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
