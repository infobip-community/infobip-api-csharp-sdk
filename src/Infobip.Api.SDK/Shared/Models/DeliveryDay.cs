using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.Shared.Models
{
    /// <summary>
    /// Defines DeliveryDay
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeliveryDay
    {
        /// <summary>
        /// Enum Monday for value: MONDAY
        /// </summary>
        [EnumMember(Value = "MONDAY")]
        Monday = 1,

        /// <summary>
        /// Enum Tuesday for value: TUESDAY
        /// </summary>
        [EnumMember(Value = "TUESDAY")]
        Tuesday = 2,

        /// <summary>
        /// Enum Wednesday for value: WEDNESDAY
        /// </summary>
        [EnumMember(Value = "WEDNESDAY")]
        Wednesday = 3,

        /// <summary>
        /// Enum Thursday for value: THURSDAY
        /// </summary>
        [EnumMember(Value = "THURSDAY")]
        Thursday = 4,

        /// <summary>
        /// Enum Friday for value: FRIDAY
        /// </summary>
        [EnumMember(Value = "FRIDAY")]
        Friday = 5,

        /// <summary>
        /// Enum Saturday for value: SATURDAY
        /// </summary>
        [EnumMember(Value = "SATURDAY")]
        Saturday = 6,

        /// <summary>
        /// Enum Sunday for value: SUNDAY
        /// </summary>
        [EnumMember(Value = "SUNDAY")]
        Sunday = 7
    }
}