using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Infobip.Api.SDK.Shared.Models;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// SendMmsMessageRequest
    /// </summary>
    public class SendMmsMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMmsMessageRequest" /> class.
        /// </summary>
        public SendMmsMessageRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMmsMessageRequest" /> class.
        /// </summary>
        /// <param name="head">Head part contains required information for sending MMS to an end user.</param>
        /// <param name="text">Body of message.</param>
        /// <param name="media"></param>
        /// <param name="externallyHostedMedia">Optional part containing information for externally hosted media (image, video).</param>
        /// <param name="smil">Optional part containing information for externally hosted media (image, video).</param>
        public SendMmsMessageRequest(MmsMessageHead head, string text = default, Stream media = default, List<ExternallyHostedMedia> externallyHostedMedia = default, string smil = default)
        {
            Head = head ?? throw new ArgumentNullException(nameof(head));
            Text = text;
            Media = media;
            ExternallyHostedMedia = externallyHostedMedia;
            Smil = smil;
        }

        /// <summary>
        /// Head part contains required information for sending MMS to an end user.
        /// </summary>
        //[JsonProperty("head")]
        [Required]
        public MmsMessageHead Head { get; }

        /// <summary>
        /// Optional part sent with content type as text/plain containing textual message data. Can be sent with different charsets.
        /// </summary>
        //[JsonProperty("text")]
        public string Text { get; }

        /// <summary>
        /// Optional part sent with content type for media containing media(image, video) message data.
        /// </summary>
        //[JsonProperty("media")]
        public Stream Media { get; }

        /// <summary>
        /// Optional part containing information for externally hosted media (image, video).
        /// </summary>
        //[JsonProperty("externallyHostedMedia")]
        public List<ExternallyHostedMedia> ExternallyHostedMedia { get; }

        /// <summary>
        /// Optional part sent with content type application/smil containing SMIL - synchronized multimedia integration language file. Used for parts ordering in MMS.
        /// </summary>
        //[JsonProperty("smil")]
        public string Smil { get; }
    }

    /// <summary>
    /// MmsMessageHead
    /// </summary>
    public class MmsMessageHead
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MmsMessageHead" /> class.
        /// </summary>
        /// <param name="from">The originator (or sender) of the message; i.e. your contact number as seen by the end user.</param>
        /// <param name="to">Mobile number to which MMS message is sent.</param>
        /// <param name="deliveryTimeWindow">Set specific scheduling options to send a message within daily or hourly intervals.</param>
        /// <param name="id">External id, if not provided id will be returned in response.</param>
        /// <param name="subject">Subject line for the MMS message.</param>
        /// <param name="validityPeriodMinutes">Validity period of message in minutes, default is 48h. After the validity period has expired message will exit send retry.</param>
        /// <param name="callbackData">Additional client's data that will be sent on the notifyUrl. The maximum value is 200 characters.</param>
        /// <param name="notifyUrl">The URL on your call back server on which the Delivery report will be sent.</param>
        /// <param name="sendAt">Date and time when the message is to be sent. Used for scheduled SMS (see [Scheduled SMS endpoints](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) for more details). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.</param>
        /// <param name="intermediateReport">The [real-time intermediate delivery report](https://www.infobip.com/docs/api#channels/sms/receive-outbound-sms-message-report) containing GSM error codes, messages status, pricing, network and country codes, etc., which will be sent on your callback server. Defaults to false.</param>
        public MmsMessageHead(string from = default, string to = default, DeliveryTimeWindow deliveryTimeWindow = default,
            string id = default, string subject = default, int? validityPeriodMinutes = default, 
            string callbackData = default, string notifyUrl = default, DateTime? sendAt = default, bool? intermediateReport = default)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            DeliveryTimeWindow = deliveryTimeWindow ?? throw new ArgumentNullException(nameof(deliveryTimeWindow));
            Id = id;
            Subject = subject;
            ValidityPeriodMinutes = validityPeriodMinutes;
            CallbackData = callbackData;
            NotifyUrl = notifyUrl;
            SendAt = sendAt;
            IntermediateReport = intermediateReport;
        }
        /// <summary>
        /// The originator (or sender) of the message; i.e. your contact number as seen by the end user.
        /// </summary>
        [JsonProperty("from")]
        [Required]
        public string From { get; }

        /// <summary>
        /// Mobile number to which MMS message is sent.
        /// </summary>
        [JsonProperty("to")]
        [Required]
        public string To { get; }

        /// <summary>
        /// External id, if not provided id will be returned in response.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Subject line for the MMS message.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; }

        /// <summary>
        /// Validity period of message in minutes, default is 48h. After the validity period has expired message will exit send retry.
        /// </summary>
        [JsonProperty("validityPeriodMinutes")]
        public int? ValidityPeriodMinutes { get; }

        /// <summary>
        /// Additional client's data that will be sent on the notifyUrl. The maximum value is 200 characters.
        /// </summary>
        [JsonProperty("callbackData")]
        [MaxLength(200)]
        public string CallbackData { get; }

        /// <summary>
        /// The URL on your call back server on which the Delivery report will be sent.
        /// </summary>
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; }

        /// <summary>
        /// Date and time when the message is to be sent. Used for scheduled SMS (see [Scheduled SMS endpoints](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) for more details). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sendAt")]
        public DateTime? SendAt { get; }

        /// <summary>
        /// The [real-time intermediate delivery report](https://www.infobip.com/docs/api#channels/sms/receive-outbound-sms-message-report) containing GSM error codes, messages status, pricing, network and country codes, etc., which will be sent on your callback server. Defaults to false.
        /// </summary>
        [JsonProperty("intermediateReport")]
        public bool? IntermediateReport { get; }

        /// <summary>
        /// Set specific scheduling options to send a message within daily or hourly intervals.
        /// </summary>
        [JsonProperty("deliveryTimeWindow")]
        [Required]
        public DeliveryTimeWindow DeliveryTimeWindow { get; set; }
    }

    /// <summary>
    /// ExternallyHostedMedia
    /// </summary>
    public class ExternallyHostedMedia
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternallyHostedMedia" /> class.
        /// </summary>
        /// <param name="contentType">Content type for media, for example 'image/png'.</param>
        /// <param name="contentId">Unique identifier for the content part.</param>
        /// <param name="contentUrl">URL for externally hosted content.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ExternallyHostedMedia(string contentType = default, string contentId = default, string contentUrl = default)
        {
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            ContentId = contentId ?? throw new ArgumentNullException(nameof(contentId));
            ContentUrl = contentUrl ?? throw new ArgumentNullException(nameof(contentUrl));
        }

        /// <summary>
        /// Content type for media, for example 'image/png'.
        /// </summary>s
        [JsonProperty("contentType")]
        [Required]
        public string ContentType { get; }

        /// <summary>
        /// Unique identifier for the content part.
        /// </summary>
        [JsonProperty("contentId")]
        [Required]
        public string ContentId { get; }

        /// <summary>
        /// URL for externally hosted content.
        /// </summary>
        [JsonProperty("contentUrl")]
        [Required]
        public string ContentUrl { get; }
    }
}
