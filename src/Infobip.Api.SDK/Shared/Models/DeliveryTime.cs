using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Shared.Models
{
    /// <summary>
    /// SmsDeliveryTime
    /// </summary>
    public class DeliveryTime
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryTime" /> class.
        /// </summary>
        [JsonConstructor]
        protected DeliveryTime() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryTime" /> class.
        /// </summary>
        /// <param name="hour">Hour when the time window opens when used in the from property or closes when used in the to property.</param>
        /// <param name="minute">Minute when the time window opens when used in the from property or closes when used in the to property.</param>
        public DeliveryTime(int hour = default, int minute = default)
        {
            Hour = hour;
            Minute = minute;
        }

        /// <summary>
        /// Hour when the time window opens when used in the from property or closes when used in the to property.
        /// </summary>
        [JsonProperty("hour")]
        [Range(0,23)]
        public int Hour { get; set; }

        /// <summary>
        /// Minute when the time window opens when used in the from property or closes when used in the to property.
        /// </summary>
        [JsonProperty("minute")]
        [Range(0, 59)]
        public int Minute { get; set; }
    }
}