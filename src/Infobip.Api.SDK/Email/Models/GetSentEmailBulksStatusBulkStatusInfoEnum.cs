using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// BulkStatusInfo Enum
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BulkStatusInfoEnum
    {
        /// <summary>
        /// Enum PENDING for value: PENDING
        /// </summary>
        [EnumMember(Value = "PENDING")]
        Pending = 1,

        /// <summary>
        /// Enum PAUSED for value: PAUSED
        /// </summary>
        [EnumMember(Value = "PAUSED")]
        Paused = 2,

        /// <summary>
        /// Enum PROCESSING for value: PROCESSING
        /// </summary>
        [EnumMember(Value = "PROCESSING")]
        Processing = 3,

        /// <summary>
        /// Enum CANCELED for value: CANCELED
        /// </summary>
        [EnumMember(Value = "CANCELED")]
        Canceled = 4,

        /// <summary>
        /// Enum FINISHED for value: FINISHED
        /// </summary>
        [EnumMember(Value = "FINISHED")]
        Finished = 5,

        /// <summary>
        /// Enum FAILED for value: FAILED
        /// </summary>
        [EnumMember(Value = "FAILED")]
        Failed = 6

    }
}