using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppBulkMessageInfoResponse
    /// </summary>
    public class WhatsAppBulkMessageInfoResponse
    {
        /// <summary>
        /// Array of sent message objects, one object per every message.
        /// </summary>
        /// <value>Array of sent message objects, one object per every message.</value>
        [JsonProperty("messages")]
        public List<WhatsAppSingleMessageInfoResponse> Messages { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address.
        /// </summary>
        /// <value>The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address.</value>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }
    }
}