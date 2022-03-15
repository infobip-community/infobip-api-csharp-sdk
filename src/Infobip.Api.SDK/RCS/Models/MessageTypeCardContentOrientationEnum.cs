using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Orientation type defines orientation in Card message
    /// </summary>
    /// <value>Orientation type defines orientation in Card message</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageTypeCardContentOrientationEnum
    {
        /// <summary>
        /// Enum HORIZONTAL for value: HORIZONTAL
        /// </summary>
        [EnumMember(Value = "HORIZONTAL")]
        Horizontal = 1,

        /// <summary>
        /// Enum VERTICAL for value: VERTICAL
        /// </summary>
        [EnumMember(Value = "VERTICAL")]
        Vertical = 2

    }
}