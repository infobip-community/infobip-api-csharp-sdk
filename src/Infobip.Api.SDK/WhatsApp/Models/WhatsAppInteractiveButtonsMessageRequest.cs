using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveButtonsMessageRequest
    /// </summary>
    public class WhatsAppInteractiveButtonsMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsMessageRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsMessageRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsMessageRequest" /> class.
        /// </summary>
        /// <param name="from">Registered WhatsApp sender number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know). (required).</param>
        /// <param name="to">Message recipient number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know). (required).</param>
        /// <param name="messageId">The ID that uniquely identifies the message sent..</param>
        /// <param name="content">content (required).</param>
        /// <param name="callbackData">Custom client data that will be included in a [Delivery Report](#channels/whatsapp/receive-whatsapp-delivery-reports)..</param>
        public WhatsAppInteractiveButtonsMessageRequest(string from = default, string to = default, string messageId = default, WhatsAppInteractiveButtonsContent content = default, string callbackData = default)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            Content = content ?? throw new ArgumentNullException(nameof(to));
            MessageId = messageId;
            CallbackData = callbackData;
        }

        /// <summary>
        /// Registered WhatsApp sender number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).
        /// </summary>
        /// <value>Registered WhatsApp sender number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).</value>
        [JsonProperty("from")]
        [Required(ErrorMessage = "From is required")]
        [MinLength(1)]
        [MaxLength(24)]
        public string From { get; set; }

        /// <summary>
        /// Message recipient number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).
        /// </summary>
        /// <value>Message recipient number. Must be in international format and comply with [WhatsApp&#39;s requirements](https://www.infobip.com/docs/whatsapp/get-started#phone-number-what-you-need-to-know).</value>
        [JsonProperty("to")]
        [Required(ErrorMessage = "To is required")]
        [MinLength(1)]
        [MaxLength(24)]
        public string To { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the message sent.
        /// </summary>
        /// <value>The ID that uniquely identifies the message sent.</value>
        [JsonProperty("messageId")]
        [MinLength(0)]
        [MaxLength(50)]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [JsonProperty("content")]
        [Required(ErrorMessage = "Content is required")]
        public WhatsAppInteractiveButtonsContent Content { get; set; }

        /// <summary>
        /// Custom client data that will be included in a [Delivery Report](https://www.infobip.com/docs/api#channels/whatsapp/receive-whatsapp-delivery-reports).
        /// </summary>
        /// <value>Custom client data that will be included in a [Delivery Report](https://www.infobip.com/docs/api#channels/whatsapp/receive-whatsapp-delivery-reports).</value>
        [JsonProperty("callbackData")]
        [MinLength(0)]
        [MaxLength(4000)]
        public string CallbackData { get; set; }

        /// <summary>
        /// The URL on your callback server to which delivery and seen reports will be sent. [Delivery report format](https://www.infobip.com/docs/api#channels/whatsapp/receive-whatsapp-delivery-reports), [Seen report format](https://www.infobip.com/docs/api#channels/whatsapp/receive-whatsapp-seen-reports).
        /// </summary>
        /// <value>Custom client data that will be included in a [Delivery report format](https://www.infobip.com/docs/api#channels/whatsapp/receive-whatsapp-delivery-reports), [Seen report format](https://www.infobip.com/docs/api#channels/whatsapp/receive-whatsapp-seen-reports).</value>
        [JsonProperty("notifyUrl")]
        [MinLength(0)]
        [MaxLength(2048)]
        public string NotifyUrl { get; set; }
    }
}