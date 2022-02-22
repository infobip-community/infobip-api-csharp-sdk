using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.Client.RCS.Models
{
    public class SendRcsMessageRequest : IValidatableObject
    {
        /// <summary>
        /// Message validity period time unit
        /// </summary>
        /// <value>Message validity period time unit</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ValidityPeriodTimeUnitEnum
        {
            /// <summary>
            /// Enum SECONDS for value: SECONDS
            /// </summary>
            [EnumMember(Value = "SECONDS")]
            SECONDS = 1,

            /// <summary>
            /// Enum MINUTES for value: MINUTES
            /// </summary>
            [EnumMember(Value = "MINUTES")]
            MINUTES = 2,

            /// <summary>
            /// Enum HOURS for value: HOURS
            /// </summary>
            [EnumMember(Value = "HOURS")]
            HOURS = 3,

            /// <summary>
            /// Enum DAYS for value: DAYS
            /// </summary>
            [EnumMember(Value = "DAYS")]
            DAYS = 4

        }


        /// <summary>
        /// Message validity period time unit
        /// </summary>
        /// <value>Message validity period time unit</value>
        [JsonProperty("validityPeriodTimeUnit")]
        public ValidityPeriodTimeUnitEnum? ValidityPeriodTimeUnit { get; set; }
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
        /// <param name="validityPeriod">Message validity period.</param>
        /// <param name="validityPeriodTimeUnit">Message validity period time unit.</param>
        /// <param name="content">content (required).</param>
        /// <param name="smsFailover">smsFailover.</param>
        /// <param name="notifyUrl">The URL on your call back server on which the Delivery report will be sent..</param>
        /// <param name="callbackData">Custom client data that will be included in Delivery Report..</param>
        /// <param name="messageId">MessageId data that will be included in Delivery Report..</param>
        public SendRcsMessageRequest(string from = default, string to = default, int validityPeriod = default, ValidityPeriodTimeUnitEnum? validityPeriodTimeUnit = default, MessageTypeContent content = default, SmsFailover smsFailover = default, string notifyUrl = default, string callbackData = default, string messageId = default)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            From = from;
            ValidityPeriod = validityPeriod;
            ValidityPeriodTimeUnit = validityPeriodTimeUnit;
            SmsFailover = smsFailover;
            NotifyUrl = notifyUrl;
            CallbackData = callbackData;
            MessageId = messageId;
        }

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

        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
