using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// RescheduleEmailMessagesRequest
    /// </summary>
    public class RescheduleEmailMessagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescheduleEmailMessagesRequest" /> class.
        /// </summary>
        [JsonConstructor]
        public RescheduleEmailMessagesRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RescheduleEmailMessagesRequest" /> class.
        /// </summary>
        /// <param name="sendAt">sendAt (required).</param>
        public RescheduleEmailMessagesRequest(DateTime sendAt)
        {
            SendAt = sendAt;
        }

        /// <summary>
        /// Gets or Sets SendAt
        /// </summary>
        [JsonProperty("sendAt")]
        [Required]
        public DateTime? SendAt { get; set; }
    }
}
