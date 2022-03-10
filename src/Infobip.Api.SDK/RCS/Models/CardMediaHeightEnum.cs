using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Height of the card media
    /// </summary>
    /// <value>Height of the card media</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardMediaHeightEnum
    {
        /// <summary>
        /// Enum SHORT for value: SHORT
        /// </summary>
        [EnumMember(Value = "SHORT")]
        Short = 1,

        /// <summary>
        /// Enum MEDIUM for value: MEDIUM
        /// </summary>
        [EnumMember(Value = "MEDIUM")]
        Medium = 2,

        /// <summary>
        /// Enum TALL for value: TALL
        /// </summary>
        [EnumMember(Value = "TALL")]
        Tall = 3

    }
}