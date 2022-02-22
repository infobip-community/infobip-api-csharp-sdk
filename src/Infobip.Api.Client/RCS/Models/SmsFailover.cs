using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.Client.RCS.Models
{
    /// <summary>
    /// RcsSms failover message contents
    /// </summary>
    public class SmsFailover : IValidatableObject
    {
        /// <summary>
        /// Message failover validity period time unit
        /// </summary>
        /// <value>Message failover validity period time unit</value>
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
        /// Message failover validity period time unit
        /// </summary>
        /// <value>Message failover validity period time unit</value>
        [JsonProperty("validityPeriodTimeUnit")]
        public ValidityPeriodTimeUnitEnum? ValidityPeriodTimeUnit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsFailover" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsFailover() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsFailover" /> class.
        /// </summary>
        /// <param name="from">Message failover sender (required).</param>
        /// <param name="text">Message failover text (required).</param>
        /// <param name="validityPeriod">Message failover validity period.</param>
        /// <param name="validityPeriodTimeUnit">Message failover validity period time unit.</param>
        public SmsFailover(string from = default, string text = default, int validityPeriod = default, ValidityPeriodTimeUnitEnum? validityPeriodTimeUnit = default)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            ValidityPeriod = validityPeriod;
            ValidityPeriodTimeUnit = validityPeriodTimeUnit;
        }

        /// <summary>
        /// Message failover sender
        /// </summary>
        /// <value>Message failover sender</value>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Message failover text
        /// </summary>
        /// <value>Message failover text</value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Message failover validity period
        /// </summary>
        /// <value>Message failover validity period</value>
        [JsonProperty("validityPeriod")]
        public int ValidityPeriod { get; set; }

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