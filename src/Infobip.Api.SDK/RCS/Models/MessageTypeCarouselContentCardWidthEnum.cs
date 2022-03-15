using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Width of cards contained within the carousel
    /// </summary>
    /// <value>Width of cards contained within the carousel</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageTypeCarouselContentCardWidthEnum
    {
        /// <summary>
        /// Enum SMALL for value: SMALL
        /// </summary>
        [EnumMember(Value = "SMALL")]
        Small = 1,

        /// <summary>
        /// Enum MEDIUM for value: MEDIUM
        /// </summary>
        [EnumMember(Value = "MEDIUM")]
        Medium = 2

    }
}