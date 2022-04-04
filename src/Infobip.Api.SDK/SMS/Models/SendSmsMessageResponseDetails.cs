using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SendSmsMessageResponseDetails
    /// </summary>
    public class SendSmsMessageResponseDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsMessageResponseDetails" /> class.
        /// </summary>
        [JsonConstructor]
        public SendSmsMessageResponseDetails() { }

        /// <summary>
        /// Unique message ID. If not passed, it will be automatically generated and returned in a response.
        /// </summary>
        /// <value>Unique message ID. If not passed, it will be automatically generated and returned in a response.</value>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Indicates the [status](https://www.infobip.com/docs/essentials/response-status-and-error-codes#api-status-codes) of the message and how to recover from an error should there be any.
        /// </summary>
        /// <value>Indicates the [status](https://www.infobip.com/docs/essentials/response-status-and-error-codes#api-status-codes) of the message and how to recover from an error should there be any.</value>
        [JsonProperty("status")]
        public SendSmsMessageResponseDetailsStatus Status { get; set; }

        /// <summary>
        /// The destination address of the message.
        /// </summary>
        /// <value>The destination address of the message.</value>
        [JsonProperty("to")]
        public string To { get; set; }
        
    }
}