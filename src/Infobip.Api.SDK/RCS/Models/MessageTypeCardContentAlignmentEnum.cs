using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Alignment type defines alignment in Card message
    /// </summary>
    /// <value>Alignment type defines alignment in Card message</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageTypeCardContentAlignmentEnum
    {
        /// <summary>
        /// Enum LEFT for value: LEFT
        /// </summary>
        [EnumMember(Value = "LEFT")]
        Left = 1,

        /// <summary>
        /// Enum RIGHT for value: RIGHT
        /// </summary>
        [EnumMember(Value = "RIGHT")]
        Right = 2

    }
}