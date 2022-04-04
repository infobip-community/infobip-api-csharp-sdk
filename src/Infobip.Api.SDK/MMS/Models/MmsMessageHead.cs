using System;
using System.ComponentModel.DataAnnotations;
using Infobip.Api.SDK.Shared.Models;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
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
        public MmsMessageHead(string from, string to, DeliveryTimeWindow deliveryTimeWindow = default,
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
        public string From { get; set; }

        /// <summary>
        /// Mobile number to which MMS message is sent.
        /// </summary>
        [JsonProperty("to")]
        [Required]
        public string To { get; set; }

        /// <summary>
        /// External id, if not provided id will be returned in response.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Subject line for the MMS message.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Validity period of message in minutes, default is 48h. After the validity period has expired message will exit send retry.
        /// </summary>
        [JsonProperty("validityPeriodMinutes")]
        public int? ValidityPeriodMinutes { get; set; }

        /// <summary>
        /// Additional client's data that will be sent on the notifyUrl. The maximum value is 200 characters.
        /// </summary>
        [JsonProperty("callbackData")]
        [MaxLength(200)]
        public string CallbackData { get; set; }

        /// <summary>
        /// The URL on your call back server on which the Delivery report will be sent.
        /// </summary>
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Date and time when the message is to be sent. Used for scheduled SMS (see [Scheduled SMS endpoints](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) for more details). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sendAt")]
        public DateTime? SendAt { get; }

        /// <summary>
        /// The [real-time intermediate delivery report](https://www.infobip.com/docs/api#channels/sms/receive-outbound-sms-message-report) containing GSM error codes, messages status, pricing, network and country codes, etc., which will be sent on your callback server. Defaults to false.
        /// </summary>
        [JsonProperty("intermediateReport")]
        public bool? IntermediateReport { get; set; }

        /// <summary>
        /// Set specific scheduling options to send a message within daily or hourly intervals.
        /// </summary>
        [JsonProperty("deliveryTimeWindow")]
        [Required]
        public DeliveryTimeWindow DeliveryTimeWindow { get; set; }
    }
}