using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Defines Card Content Suggestion Type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardContentSuggestionTypeEnum
    {
        /// <summary>
        /// Enum REPLY for value: REPLY
        /// </summary>
        [EnumMember(Value = "REPLY")]
        Reply = 1,

        /// <summary>
        /// Enum OPENURL for value: OPEN_URL
        /// </summary>
        [EnumMember(Value = "OPEN_URL")]
        OpenUrl = 2,

        /// <summary>
        /// Enum DIALPHONE for value: DIAL_PHONE
        /// </summary>
        [EnumMember(Value = "DIAL_PHONE")]
        DialPhone = 3,

        /// <summary>
        /// Enum SHOWLOCATION for value: SHOW_LOCATION
        /// </summary>
        [EnumMember(Value = "SHOW_LOCATION")]
        ShowLocation = 4,

        /// <summary>
        /// Enum REQUESTLOCATION for value: REQUEST_LOCATION
        /// </summary>
        [EnumMember(Value = "REQUEST_LOCATION")]
        RequestLocation = 5

    }
}