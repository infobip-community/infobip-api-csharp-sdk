using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WebRtc.Models
{
    /// <summary>
    /// Optional. The object containing permission for certain actions during the session.
    /// </summary>
    public class WebRtcCapabilities : IValidatableObject
    {
        /// <summary>
        /// Whether to allow recording calls during the session. Possible values are &#x60;ALWAYS&#x60;, &#x60;ON_DEMAND&#x60; and &#x60;DISABLED&#x60;. If want to set &#x60;ALWAYS&#x60; or &#x60;ON_DEMAND&#x60;, the capability must be enabled on account level (please contact your account manager for this).
        /// </summary>
        /// <value>Whether to allow recording calls during the session. Possible values are &#x60;ALWAYS&#x60;, &#x60;ON_DEMAND&#x60; and &#x60;DISABLED&#x60;. If want to set &#x60;ALWAYS&#x60; or &#x60;ON_DEMAND&#x60;, the capability must be enabled on account level (please contact your account manager for this).</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RecordingEnum
        {
            /// <summary>
            /// Enum ALWAYS for value: ALWAYS
            /// </summary>
            [EnumMember(Value = "ALWAYS")]
            ALWAYS = 1,

            /// <summary>
            /// Enum ONDEMAND for value: ON_DEMAND
            /// </summary>
            [EnumMember(Value = "ON_DEMAND")]
            ONDEMAND = 2,

            /// <summary>
            /// Enum DISABLED for value: DISABLED
            /// </summary>
            [EnumMember(Value = "DISABLED")]
            DISABLED = 3

        }


        /// <summary>
        /// Whether to allow recording calls during the session. Possible values are &#x60;ALWAYS&#x60;, &#x60;ON_DEMAND&#x60; and &#x60;DISABLED&#x60;. If want to set &#x60;ALWAYS&#x60; or &#x60;ON_DEMAND&#x60;, the capability must be enabled on account level (please contact your account manager for this).
        /// </summary>
        /// <value>Whether to allow recording calls during the session. Possible values are &#x60;ALWAYS&#x60;, &#x60;ON_DEMAND&#x60; and &#x60;DISABLED&#x60;. If want to set &#x60;ALWAYS&#x60; or &#x60;ON_DEMAND&#x60;, the capability must be enabled on account level (please contact your account manager for this).</value>
        [JsonProperty("recording")]
        public RecordingEnum? Recording { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebRtcCapabilities" /> class.
        /// </summary>
        /// <param name="recording">Whether to allow recording calls during the session. Possible values are &#x60;ALWAYS&#x60;, &#x60;ON_DEMAND&#x60; and &#x60;DISABLED&#x60;. If want to set &#x60;ALWAYS&#x60; or &#x60;ON_DEMAND&#x60;, the capability must be enabled on account level (please contact your account manager for this)..</param>
        public WebRtcCapabilities(RecordingEnum? recording = default)
        {
            Recording = recording;
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}