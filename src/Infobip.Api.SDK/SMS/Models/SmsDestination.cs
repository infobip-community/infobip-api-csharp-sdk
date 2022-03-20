using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsDestination
    /// </summary>
    public class SmsDestination 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsDestination" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsDestination() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsDestination" /> class.
        /// </summary>
        /// <param name="messageId">The ID that uniquely identifies the message sent.</param>
        /// <param name="to">Message destination address. Addresses must be in international format (Example: 41793026727).</param>
        public SmsDestination(string messageId = default, string to = default)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
            MessageId = messageId;
        }

        /// <summary>
        /// The ID that uniquely identifies the message sent.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Message destination address. Addresses must be in international format (Example: 41793026727).
        /// </summary>
        [JsonProperty("to")]
        [Required]
        public string To { get; set; }
    }
}