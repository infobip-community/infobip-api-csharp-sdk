using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SendSmsBinaryMessageRequest
    /// </summary>
    public class SendSmsBinaryMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsBinaryMessageRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected SendSmsBinaryMessageRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsBinaryMessageRequest" /> class.
        /// </summary>
        /// <param name="bulkId">
        /// The ID which uniquely identifies the request. Bulk ID will be received only when you send a
        /// message to more than one destination address..
        /// </param>
        /// <param name="messages">An array of message objects of a single message or multiple messages sent under one bulk ID.</param>
        /// <param name="sendingSpeedLimit">Limits the send speed when sending messages in bulk to deliver messages over a longer period of time. You may wish to use this to allow your systems or agents to handle large amounts of incoming traffic, e.g., if you are expecting recipients to follow through with a call-to-action option from a message you sent. Not setting a send speed limit can overwhelm your resources with incoming traffic.</param>
        public SendSmsBinaryMessageRequest(string bulkId = default,
            List<SmsBinaryMessage> messages = default,
            SmsSendingSpeedLimit sendingSpeedLimit = default)
        {
            Messages = messages ?? throw new ArgumentNullException(nameof(messages));
            BulkId = bulkId;
            SendingSpeedLimit = sendingSpeedLimit;
        }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request. If not provided, it will be auto-generated and returned in the API response. Typically, used to fetch [delivery reports](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-delivery-reports) and [message logs](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-logs).
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// An array of message objects of a single message or multiple messages sent under one bulk ID.
        /// </summary>
        [JsonProperty("messages")]
        [Required]
        [MinLength(1)]
        public List<SmsBinaryMessage> Messages { get; set; }

        /// <summary>
        /// Limits the send speed when sending messages in bulk to deliver messages over a longer period of time. You may wish to use this to allow your systems or agents to handle large amounts of incoming traffic, e.g., if you are expecting recipients to follow through with a call-to-action option from a message you sent. Not setting a send speed limit can overwhelm your resources with incoming traffic.
        /// </summary>
        [JsonProperty("sendingSpeedLimit")]
        public SmsSendingSpeedLimit SendingSpeedLimit { get; set; }
    }
}