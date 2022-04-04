using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Defines TfaPinType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TfaPinType
    {
        /// <summary>
        /// Enum Numeric for value: NUMERIC
        /// </summary>
        [EnumMember(Value = "NUMERIC")]
        Numeric = 1,

        /// <summary>
        /// Enum Alpha for value: ALPHA
        /// </summary>
        [EnumMember(Value = "ALPHA")]
        Alpha = 2,

        /// <summary>
        /// Enum Hex for value: HEX
        /// </summary>
        [EnumMember(Value = "HEX")]
        Hex = 3,

        /// <summary>
        /// Enum Alphanumeric for value: ALPHANUMERIC
        /// </summary>
        [EnumMember(Value = "ALPHANUMERIC")]
        Alphanumeric = 4
    }
}