using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Message type, describing type of message which is going to be sent over RCS
    /// </summary>
    /// <value>Message type, describing type of message which is going to be sent over RCS</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageTypeContentTypeEnum
    {
        /// <summary>
        /// Enum TEXT for value: TEXT
        /// </summary>
        [EnumMember(Value = "TEXT")]
        Text = 1,

        /// <summary>
        /// Enum FILE for value: FILE
        /// </summary>
        [EnumMember(Value = "FILE")]
        File = 2,

        /// <summary>
        /// Enum CARD for value: CARD
        /// </summary>
        [EnumMember(Value = "CARD")]
        Card = 3,

        /// <summary>
        /// Enum CAROUSEL for value: CAROUSEL
        /// </summary>
        [EnumMember(Value = "CAROUSEL")]
        Carousel = 4

    }
}