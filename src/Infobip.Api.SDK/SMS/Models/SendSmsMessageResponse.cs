using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SendSmsMessageResponse
    /// </summary>
    public class SendSmsMessageResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsMessageResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public SendSmsMessageResponse() { }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request. Typically, used to fetch [delivery reports](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-delivery-reports) and [message logs](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-logs).
        /// </summary>
        /// <value>Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request. Typically, used to fetch [delivery reports](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-delivery-reports) and [message logs](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-logs).</value>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// An array of message objects of a single message or multiple messages sent under one bulk ID.
        /// </summary>
        /// <value>An array of message objects of a single message or multiple messages sent under one bulk ID.</value>
        [JsonProperty("messages")]
        public List<SendSmsMessageResponseDetails> Messages { get; set; }

    }
}
