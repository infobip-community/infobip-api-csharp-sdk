using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// RcsSms failover message contents
    /// </summary>
    public class SmsFailover
    {
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
        public SmsFailover(string from, string text, ValidityPeriodTimeUnitEnum validityPeriodTimeUnit, int validityPeriod = default)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            ValidityPeriod = validityPeriod;
            ValidityPeriodTimeUnit = validityPeriodTimeUnit;
        }

        /// <summary>
        /// Message failover validity period time unit
        /// </summary>
        /// <value>Message failover validity period time unit</value>
        [JsonProperty("validityPeriodTimeUnit")]
        [Required(ErrorMessage = "ValidityPeriodTimeUnit is required")]
        public ValidityPeriodTimeUnitEnum ValidityPeriodTimeUnit { get; set; }


        /// <summary>
        /// Message failover sender
        /// </summary>
        /// <value>Message failover sender</value>
        [JsonProperty("from")]
        [Required(ErrorMessage = "From is required")]
        public string From { get; set; }

        /// <summary>
        /// Message failover text
        /// </summary>
        /// <value>Message failover text</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        /// <summary>
        /// Message failover validity period
        /// </summary>
        /// <value>Message failover validity period</value>
        [JsonProperty("validityPeriod")]
        public int ValidityPeriod { get; set; }
    }
}