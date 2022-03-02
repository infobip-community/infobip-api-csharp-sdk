using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Type of the phone number. Can be &#x60;CELL&#x60;, &#x60;MAIN&#x60;, &#x60;IPHONE&#x60;, &#x60;HOME&#x60; or &#x60;WORK&#x60;.
    /// </summary>
    /// <value>Type of the phone number. Can be &#x60;CELL&#x60;, &#x60;MAIN&#x60;, &#x60;IPHONE&#x60;, &#x60;HOME&#x60; or &#x60;WORK&#x60;.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WhatsAppPhoneType
    {
        /// <summary>
        /// Enum CELL for value: CELL
        /// </summary>
        [EnumMember(Value = "CELL")]
        Cell = 1,

        /// <summary>
        /// Enum MAIN for value: MAIN
        /// </summary>
        [EnumMember(Value = "MAIN")]
        Main = 2,

        /// <summary>
        /// Enum IPHONE for value: IPHONE
        /// </summary>
        [EnumMember(Value = "IPHONE")]
        Iphone = 3,

        /// <summary>
        /// Enum HOME for value: HOME
        /// </summary>
        [EnumMember(Value = "HOME")]
        Home = 4,

        /// <summary>
        /// Enum WORK for value: WORK
        /// </summary>
        [EnumMember(Value = "WORK")]
        Work = 5

    }
}