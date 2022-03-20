using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SendSmsMessageRequest
    /// </summary>
    public class SendSmsMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsMessageRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected SendSmsMessageRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsMessageRequest" /> class.
        /// </summary>
        /// <param name="bulkId">Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request. If not provided, it will be auto-generated and returned in the API response. Typically, used to fetch [delivery reports](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-delivery-reports) and [message logs](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-logs).</param>
        /// <param name="messages">An array of message objects of a single message or multiple messages sent under one bulk ID.</param>
        /// <param name="sendingSpeedLimit">Limits the send speed when sending messages in bulk to deliver messages over a longer period of time. You may wish to use this to allow your systems or agents to handle large amounts of incoming traffic, e.g., if you are expecting recipients to follow through with a call-to-action option from a message you sent. Not setting a send speed limit can overwhelm your resources with incoming traffic.</param>
        /// <param name="tracking">Sets up tracking parameters to track conversion metrics and type.</param>
        public SendSmsMessageRequest(string bulkId = default,
            List<SmsMessage> messages = default,
            SmsSendingSpeedLimit sendingSpeedLimit = default,
            SmsTracking tracking = default)
        {
            BulkId = bulkId;
            Messages = messages;
            SendingSpeedLimit = sendingSpeedLimit;
            Tracking = tracking;
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
        public List<SmsMessage> Messages { get; set; }

        /// <summary>
        /// Limits the send speed when sending messages in bulk to deliver messages over a longer period of time. You may wish to use this to allow your systems or agents to handle large amounts of incoming traffic, e.g., if you are expecting recipients to follow through with a call-to-action option from a message you sent. Not setting a send speed limit can overwhelm your resources with incoming traffic.
        /// </summary>
        [JsonProperty("sendingSpeedLimit")]
        public SmsSendingSpeedLimit SendingSpeedLimit { get; set; }

        /// <summary>
        /// Sets up tracking parameters to track conversion metrics and type.
        /// </summary>
        [JsonProperty("tracking")]
        public SmsTracking Tracking { get; set; }
    }
}
