using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsDeliveryTime
    /// </summary>
    public class SmsDeliveryTime
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsDeliveryTime" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsDeliveryTime()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsDeliveryTime" /> class.
        /// </summary>
        /// <param name="hour">Hour when the time window opens when used in the from property or closes when used in the to property.</param>
        /// <param name="minute">Minute when the time window opens when used in the from property or closes when used in the to property.</param>
        public SmsDeliveryTime(int hour = default, int minute = default)
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