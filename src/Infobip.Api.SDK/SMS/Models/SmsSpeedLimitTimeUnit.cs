using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsSpeedLimitTimeUnit
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SmsSpeedLimitTimeUnit
    {
        /// <summary>
        /// Enum Minute for value: MINUTE
        /// </summary>
        [EnumMember(Value = "MINUTE")]
        Minute = 1,

        /// <summary>
        /// Enum Hour for value: HOUR
        /// </summary>
        [EnumMember(Value = "HOUR")]
        Hour = 2,

        /// <summary>
        /// Enum Day for value: DAY
        /// </summary>
        [EnumMember(Value = "DAY")] 
        Day = 3
    }
}