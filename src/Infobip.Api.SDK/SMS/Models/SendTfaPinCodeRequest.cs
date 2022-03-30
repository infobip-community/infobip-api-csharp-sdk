using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SendTfaPinCodeRequest
    /// </summary>
    public class SendTfaPinCodeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendTfaPinCodeRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected SendTfaPinCodeRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendTfaPinCodeRequest" /> class.
        /// </summary>
        /// <param name="applicationId">The ID of the application that represents your service, e.g. 2FA for login, 2FA for changing the password, etc. (required).</param>
        /// <param name="messageId">The ID of the message template (message body with the PIN placeholder) that is sent to the recipient. (required).</param>
        /// <param name="to">Phone number to which the 2FA message will be sent. Example: 41793026727. (required).</param>
        /// <param name="ncNeeded">Indicates if Number Lookup is needed before sending the 2FA message. If the parameter value is true, Number Lookup will be requested before sending the SMS. If the value is false, the SMS will be sent without requesting Number Lookup. Field's default value is true.</param>
        /// <param name="from">Use this parameter if you wish to override the sender ID from the [created](https://www.infobip.com/docs/api#channels/sms/create-2fa-message-template) message template parameter senderId.</param>
        /// <param name="placeholders">Key value pairs that will be replaced during message sending. Placeholder keys should NOT contain curly brackets and should NOT contain a pin placeholder. Valid example: "placeholders":{"firstName":"John"}</param>
        public SendTfaPinCodeRequest(string applicationId = default, string messageId = default, string to = default, 
            string from = default, bool ncNeeded = true, Dictionary<string, string> placeholders = default)
        {
            ApplicationId = applicationId ?? throw new ArgumentNullException(nameof(applicationId));
            MessageId = messageId ?? throw new ArgumentNullException(nameof(messageId));
            To = to ?? throw new ArgumentNullException(nameof(to));
            NcNeeded = ncNeeded;
            From = from;
            Placeholders = placeholders;
        }

        /// <summary>
        /// Indicates if Number Lookup is needed before sending the 2FA message. If the parameter value is true, Number Lookup will be requested before sending the SMS. If the value is false, the SMS will be sent without requesting Number Lookup. Field's default value is true.
        /// </summary>
        [JsonIgnore]
        public bool NcNeeded { get; set; }

        /// <summary>
        /// The ID of the application that represents your service, e.g. 2FA for login, 2FA for changing the password, etc.
        /// </summary>
        [JsonProperty("applicationId")]
        [Required]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Use this parameter if you wish to override the sender ID from the [created](https://www.infobip.com/docs/api#channels/sms/create-2fa-message-template) message template parameter senderId.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// The ID of the message template (message body with the PIN placeholder) that is sent to the recipient.
        /// </summary>
        [JsonProperty("messageId")]
        [Required]
        public string MessageId { get; set; }

        /// <summary>
        /// Key value pairs that will be replaced during message sending. Placeholder keys should NOT contain curly brackets and should NOT contain a pin placeholder. Valid example: "placeholders":{"firstName":"John"}
        /// </summary>
        [JsonProperty("placeholders")]
        public Dictionary<string, string> Placeholders { get; set; }

        /// <summary>
        /// Phone number to which the 2FA message will be sent. Example: 41793026727.
        /// </summary>
        [JsonProperty("to")]
        [Required]
        public string To { get; set; }
    }
}
