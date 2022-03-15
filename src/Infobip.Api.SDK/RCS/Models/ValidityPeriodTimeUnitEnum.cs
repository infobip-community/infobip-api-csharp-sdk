using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
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
        Seconds = 1,

        /// <summary>
        /// Enum MINUTES for value: MINUTES
        /// </summary>
        [EnumMember(Value = "MINUTES")]
        Minutes = 2,

        /// <summary>
        /// Enum HOURS for value: HOURS
        /// </summary>
        [EnumMember(Value = "HOURS")]
        Hours = 3,

        /// <summary>
        /// Enum DAYS for value: DAYS
        /// </summary>
        [EnumMember(Value = "DAYS")]
        Days = 4

    }
}