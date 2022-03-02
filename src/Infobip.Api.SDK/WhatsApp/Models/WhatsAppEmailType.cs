using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Type of the email. Can be &#x60;HOME&#x60; or &#x60;WORK&#x60;.
    /// </summary>
    /// <value>Type of the email. Can be &#x60;HOME&#x60; or &#x60;WORK&#x60;.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WhatsAppEmailType
    {
        /// <summary>
        /// Enum HOME for value: HOME
        /// </summary>
        [EnumMember(Value = "HOME")]
        Home = 1,

        /// <summary>
        /// Enum WORK for value: WORK
        /// </summary>
        [EnumMember(Value = "WORK")]
        Work = 2

    }
}