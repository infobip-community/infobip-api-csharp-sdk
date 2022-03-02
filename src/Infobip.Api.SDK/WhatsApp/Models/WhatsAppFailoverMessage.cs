using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// An array of messages being sent.
    /// </summary>
    public class WhatsAppFailoverMessage : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppFailoverMessage" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppFailoverMessage() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppFailoverMessage" /> class.
        /// </summary>
        /// <param name="from">Registered WhatsApp sender number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know). (required).</param>
        /// <param name="to">Message recipient number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know). (required).</param>
        /// <param name="messageId">The ID that uniquely identifies the message sent..</param>
        /// <param name="content">content (required).</param>
        /// <param name="callbackData">Custom client data that will be included in a [Delivery Report](#channels/whatsapp/receive-whatsapp-delivery-reports)..</param>
        /// <param name="smsFailover">smsFailover.</param>
        public WhatsAppFailoverMessage(string from = default, string to = default, string messageId = default, WhatsAppTemplateContent content = default, string callbackData = default, WhatsAppSmsFailover smsFailover = default)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            MessageId = messageId;
            CallbackData = callbackData;
            SmsFailover = smsFailover;
        }

        /// <summary>
        /// Registered WhatsApp sender number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).
        /// </summary>
        /// <value>Registered WhatsApp sender number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).</value>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Message recipient number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).
        /// </summary>
        /// <value>Message recipient number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).</value>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the message sent.
        /// </summary>
        /// <value>The ID that uniquely identifies the message sent.</value>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [JsonProperty("content")]
        public WhatsAppTemplateContent Content { get; set; }

        /// <summary>
        /// Custom client data that will be included in a [Delivery Report](#channels/whatsapp/receive-whatsapp-delivery-reports).
        /// </summary>
        /// <value>Custom client data that will be included in a [Delivery Report](#channels/whatsapp/receive-whatsapp-delivery-reports).</value>
        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Gets or Sets SmsFailover
        /// </summary>
        [JsonProperty("smsFailover")]
        public WhatsAppSmsFailover SmsFailover { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // From (string) maxLength
            if (From != null && From.Length > 24)
            {
                yield return new ValidationResult("Invalid value for From, length must be less than 24.", new[] { "From" });
            }

            // From (string) minLength
            if (From != null && From.Length < 1)
            {
                yield return new ValidationResult("Invalid value for From, length must be greater than 1.", new[] { "From" });
            }

            // To (string) maxLength
            if (To != null && To.Length > 24)
            {
                yield return new ValidationResult("Invalid value for To, length must be less than 24.", new[] { "To" });
            }

            // To (string) minLength
            if (To != null && To.Length < 1)
            {
                yield return new ValidationResult("Invalid value for To, length must be greater than 1.", new[] { "To" });
            }

            // MessageId (string) maxLength
            if (MessageId != null && MessageId.Length > 50)
            {
                yield return new ValidationResult("Invalid value for MessageId, length must be less than 50.", new[] { "MessageId" });
            }

            // MessageId (string) minLength
            if (MessageId != null && MessageId.Length < 0)
            {
                yield return new ValidationResult("Invalid value for MessageId, length must be greater than 0.", new[] { "MessageId" });
            }

            // CallbackData (string) maxLength
            if (CallbackData != null && CallbackData.Length > 4000)
            {
                yield return new ValidationResult("Invalid value for CallbackData, length must be less than 4000.", new[] { "CallbackData" });
            }

            // CallbackData (string) minLength
            if (CallbackData != null && CallbackData.Length < 0)
            {
                yield return new ValidationResult("Invalid value for CallbackData, length must be greater than 0.", new[] { "CallbackData" });
            }

            yield break;
        }
    }
}