﻿using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// SendRcsMessageRequest
    /// </summary>
    public class SendRcsMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendRcsMessageRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected SendRcsMessageRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendRcsMessageRequest" /> class.
        /// </summary>
        /// <param name="from">Message sender.</param>
        /// <param name="to">Message destination (required).</param>
        /// <param name="content">content (required).</param>
        /// <param name="validityPeriod">Message validity period.</param>
        /// <param name="validityPeriodTimeUnit">Message validity period time unit.</param>
        /// <param name="smsFailover">smsFailover.</param>
        /// <param name="notifyUrl">The URL on your call back server on which the Delivery report will be sent..</param>
        /// <param name="callbackData">Custom client data that will be included in Delivery Report..</param>
        /// <param name="messageId">MessageId data that will be included in Delivery Report..</param>
        public SendRcsMessageRequest(string from, string to, MessageTypeContent content, int validityPeriod = default, ValidityPeriodTimeUnitEnum? validityPeriodTimeUnit = default, SmsFailover smsFailover = default, string notifyUrl = default, string callbackData = default, string messageId = default)
        {
            From = from;
            To = to ?? throw new ArgumentNullException(nameof(to));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            ValidityPeriod = validityPeriod;
            ValidityPeriodTimeUnit = validityPeriodTimeUnit;
            SmsFailover = smsFailover;
            NotifyUrl = notifyUrl;
            CallbackData = callbackData;
            MessageId = messageId;
        }

        /// <summary>
        /// Message validity period time unit
        /// </summary>
        /// <value>Message validity period time unit</value>
        [JsonProperty("validityPeriodTimeUnit")]
        public ValidityPeriodTimeUnitEnum? ValidityPeriodTimeUnit { get; set; }

        /// <summary>
        /// Message sender
        /// </summary>
        /// <value>Message sender</value>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Message destination
        /// </summary>
        /// <value>Message destination</value>
        [JsonProperty("to")]
        [Required(ErrorMessage = "To is required")]
        public string To { get; set; }

        /// <summary>
        /// Message validity period
        /// </summary>
        /// <value>Message validity period</value>
        [JsonProperty("validityPeriod")]
        public int ValidityPeriod { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [JsonProperty("content", Required = Required.Always)]
        [Required(ErrorMessage = "Content is required")]
        public MessageTypeContent Content { get; set; }

        /// <summary>
        /// Gets or Sets SmsFailover
        /// </summary>
        [JsonProperty("smsFailover")]
        public SmsFailover SmsFailover { get; set; }

        /// <summary>
        /// The URL on your call back server on which the Delivery report will be sent.
        /// </summary>
        /// <value>The URL on your call back server on which the Delivery report will be sent.</value>
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Custom client data that will be included in Delivery Report.
        /// </summary>
        /// <value>Custom client data that will be included in Delivery Report.</value>
        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        /// <summary>
        /// MessageId data that will be included in Delivery Report.
        /// </summary>
        /// <value>MessageId data that will be included in Delivery Report.</value>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
    }
}
