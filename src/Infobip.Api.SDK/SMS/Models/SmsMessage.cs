﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infobip.Api.SDK.Shared.Models;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsMessage
    /// </summary>
    public class SmsMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsMessage" /> class.
        /// </summary>
        /// <param name="callbackData">Additional data that can be used for identifying, managing, or monitoring a message. Data included here will also be automatically included in the message Delivery Report. The maximum value is 4000 characters and any overhead may be truncated.</param>
        /// <param name="deliveryTimeWindow">Sets specific scheduling options to send a message within daily or hourly intervals.</param>
        /// <param name="destinations">An array of destination objects for where messages are being sent. A valid destination is required.</param>
        /// <param name="flash">Allows for sending a flash SMS to automatically appear on recipient devices without interaction. Set to true to enable [flash SMS](https://www.infobip.com/docs/sms/message-types#flash-sms), or leave the default value, false to send a standard SMS.</param>
        /// <param name="from">The sender ID which can be alphanumeric or numeric (e.g., CompanyName). Make sure you don't exceed [character limit](https://www.infobip.com/docs/sms/get-started#sender-names).</param>
        /// <param name="intermediateReport">The real-time intermediate delivery report containing GSM error codes, messages status, pricing, network and country codes, etc., which will be sent on your callback server. Defaults to false.</param>
        /// <param name="language">Sets the language parameters for the message being sent.</param>
        /// <param name="notifyContentType">Preferred delivery report content type, application/json or application/xml.</param>
        /// <param name="notifyUrl">The URL on your call back server on to which a delivery report will be sent.
        /// The retry cycle for when your URL becomes unavailable uses the following formula: 1min + (1min * retryNumber * retryNumber).
        /// [Delivery report format](https://www.infobip.com/docs/api#channels/sms/receive-sent-sms-report)</param>
        /// <param name="regional">Region-specific parameters, often imposed by local laws. Use this, if country or region that you are sending an SMS to requires additional information.</param>
        /// <param name="sendAt">Date and time when the message is to be sent. Used for scheduled SMS. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ. Must be sooner than 180 days from now.</param>
        /// <param name="text">Content of the message being sent.</param>
        /// <param name="transliteration">The transliteration of your sent message from one script to another. Transliteration is used to replace characters which are not recognized as part of your defaulted alphabet. Possible values: TURKISH, GREEK, CYRILLIC, SERBIAN_CYRILLIC, CENTRAL_EUROPEAN, BALTIC and NON_UNICODE.</param>
        /// <param name="validityPeriod">The message validity period in minutes. When the period expires, it will not be allowed for the message to be sent. Validity period longer than 48h is not supported. Any bigger value will automatically default back to 2880.</param>
        public SmsMessage(string callbackData = default,
            DeliveryTimeWindow deliveryTimeWindow = default,
            List<SmsDestination> destinations = default, bool flash = default,
            string from = default, bool intermediateReport = default, SmsLanguage language = default,
            string notifyContentType = default, string notifyUrl = default,
            SmsRegionalOptions regional = default, DateTimeOffset sendAt = default,
            string text = default, string transliteration = default,
            long validityPeriod = default)
        {
            CallbackData = callbackData;
            DeliveryTimeWindow = deliveryTimeWindow;
            Destinations = destinations;
            Flash = flash;
            From = from;
            IntermediateReport = intermediateReport;
            Language = language;
            NotifyContentType = notifyContentType;
            NotifyUrl = notifyUrl;
            Regional = regional;
            SendAt = sendAt;
            Text = text;
            Transliteration = transliteration;
            ValidityPeriod = validityPeriod;
        }

        /// <summary>
        /// Additional data that can be used for identifying, managing, or monitoring a message. Data included here will also be automatically included in the message Delivery Report. The maximum value is 4000 characters and any overhead may be truncated.
        /// </summary>
        [JsonProperty("callbackData")]
        [StringLength(4000)]
        public string CallbackData { get; set; }

        /// <summary>
        /// Sets specific scheduling options to send a message within daily or hourly intervals.
        /// </summary>
        [JsonProperty("deliveryTimeWindow")]
        public DeliveryTimeWindow DeliveryTimeWindow { get; set; }

        /// <summary>
        /// An array of destination objects for where messages are being sent. A valid destination is required.
        /// </summary>
        [JsonProperty("destinations")]
        [Required]
        [MinLength(1)]
        public List<SmsDestination> Destinations { get; set; }

        /// <summary>
        /// Allows for sending a flash SMS to automatically appear on recipient devices without interaction. Set to true to enable [flash SMS](https://www.infobip.com/docs/sms/message-types#flash-sms), or leave the default value, false to send a standard SMS.
        /// </summary>
        [JsonProperty("flash")]
        public bool Flash { get; set; }

        /// <summary>
        /// The sender ID which can be alphanumeric or numeric (e.g., CompanyName). Make sure you don't exceed [character limit](https://www.infobip.com/docs/sms/get-started#sender-names).
        /// </summary>
        [JsonProperty("from")]
        [Required]
        public string From { get; set; }

        /// <summary>
        /// The real-time intermediate delivery report containing GSM error codes, messages status, pricing, network and country codes, etc., which will be sent on your callback server. Defaults to false.
        /// </summary>
        [JsonProperty("intermediateReport")]
        public bool IntermediateReport { get; set; }

        /// <summary>
        /// Sets the language parameters for the message being sent.
        /// </summary>
        [JsonProperty("language")]
        public SmsLanguage Language { get; set; }

        /// <summary>
        /// Preferred delivery report content type, application/json or application/xml.
        /// </summary>
        [JsonProperty("notifyContentType")]
        public string NotifyContentType { get; set; }

        /// <summary>
        /// The URL on your call back server on to which a delivery report will be sent.
        /// The retry cycle for when your URL becomes unavailable uses the following formula: 1min + (1min * retryNumber * retryNumber).
        /// [Delivery report format](https://www.infobip.com/docs/api#channels/sms/receive-sent-sms-report)
        /// </summary>
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Region-specific parameters, often imposed by local laws. Use this, if country or region that you are sending an SMS to requires additional information.
        /// </summary>
        [JsonProperty("regional")]
        public SmsRegionalOptions Regional { get; set; }

        /// <summary>
        /// Date and time when the message is to be sent. Used for scheduled SMS. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ. Must be sooner than 180 days from now.
        /// </summary>
        [JsonProperty("sendAt")]
        public DateTimeOffset SendAt { get; set; }

        /// <summary>
        /// Content of the message being sent.
        /// </summary>
        [JsonProperty("text")]
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// The transliteration of your sent message from one script to another. Transliteration is used to replace characters which are not recognized as part of your defaulted alphabet. Possible values: TURKISH, GREEK, CYRILLIC, SERBIAN_CYRILLIC, CENTRAL_EUROPEAN, BALTIC and NON_UNICODE.
        /// </summary>
        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }

        /// <summary>
        /// The message validity period in minutes. When the period expires, it will not be allowed for the message to be sent. Validity period longer than 48h is not supported. Any bigger value will automatically default back to 2880.
        /// </summary>
        [JsonProperty("validityPeriod")]
        public long ValidityPeriod { get; set; }
    }
}