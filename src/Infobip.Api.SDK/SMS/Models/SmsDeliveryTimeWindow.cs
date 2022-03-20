using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Sets specific scheduling options to send a message within daily or hourly intervals.
    /// </summary>
    public class SmsDeliveryTimeWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsDeliveryTimeWindow" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsDeliveryTimeWindow() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsDeliveryTimeWindow" /> class.
        /// </summary>
        /// <param name="days">Days of the week which are included in the delivery time window. At least one day must be provided. Separate multiple days with a comma.</param>
        /// <param name="from">The exact time of day to start sending messages. Time is expressed in the UTC time zone. If set, use it together with the to property with minimum 1 hour difference.</param>
        /// <param name="to">The exact time of day to end sending messages. Time is expressed in the UTC time zone. If set, use it together with the from property with minimum 1 hour difference.</param>
        public SmsDeliveryTimeWindow(List<SmsDeliveryDay> days = default,
            SmsDeliveryTime from = default, SmsDeliveryTime to = default)
        {
            // to ensure "days" is required (not null)
            Days = days ?? throw new ArgumentNullException(nameof(days));
            From = from;
            To = to;
        }

        /// <summary>
        /// Days of the week which are included in the delivery time window. At least one day must be provided. Separate multiple days with a comma.
        /// </summary>
        [JsonProperty("days")]
        [Required]
        public List<SmsDeliveryDay> Days { get; set; }

        /// <summary>
        /// The exact time of day to start sending messages. Time is expressed in the UTC time zone. If set, use it together with the to property with minimum 1 hour difference.
        /// </summary>
        [JsonProperty("from")]
        public SmsDeliveryTime From { get; set; }

        /// <summary>
        ///The exact time of day to end sending messages. Time is expressed in the UTC time zone. If set, use it together with the from property with minimum 1 hour difference.
        /// </summary>
        [JsonProperty("to")]
        public SmsDeliveryTime To { get; set; }
    }
}