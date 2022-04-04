using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Shared.Models
{
    /// <summary>
    /// Sets specific scheduling options to send a message within daily or hourly intervals.
    /// </summary>
    public class DeliveryTimeWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryTimeWindow" /> class.
        /// </summary>
        [JsonConstructor]
        protected DeliveryTimeWindow() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryTimeWindow" /> class.
        /// </summary>
        /// <param name="days">Days of the week which are included in the delivery time window. At least one day must be provided. Separate multiple days with a comma.</param>
        /// <param name="from">The exact time of day to start sending messages. Time is expressed in the UTC time zone. If set, use it together with the to property with minimum 1 hour difference.</param>
        /// <param name="to">The exact time of day to end sending messages. Time is expressed in the UTC time zone. If set, use it together with the from property with minimum 1 hour difference.</param>
        public DeliveryTimeWindow(List<DeliveryDay> days = default,
            DeliveryTime from = default, DeliveryTime to = default)
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
        public List<DeliveryDay> Days { get; set; }

        /// <summary>
        /// The exact time of day to start sending messages. Time is expressed in the UTC time zone. If set, use it together with the to property with minimum 1 hour difference.
        /// </summary>
        [JsonProperty("from")]
        public DeliveryTime From { get; set; }

        /// <summary>
        ///The exact time of day to end sending messages. Time is expressed in the UTC time zone. If set, use it together with the from property with minimum 1 hour difference.
        /// </summary>
        [JsonProperty("to")]
        public DeliveryTime To { get; set; }
    }
}