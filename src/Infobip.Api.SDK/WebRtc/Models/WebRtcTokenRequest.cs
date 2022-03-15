using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WebRtc.Models
{
    /// <summary>
    /// WebRtcTokenRequest
    /// </summary>
    public class WebRtcTokenRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebRtcTokenRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected WebRtcTokenRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRtcTokenRequest" /> class.
        /// </summary>
        /// <param name="identity">The identity used to present user on Infobip WebRTC platform. Must be unique. Must contain at least 3 and at most 64 unicode characters including -, _, .. (required).</param>
        /// <param name="applicationId">Application ID to be used for calls. Web and In-App application represents one-stop place for all your configuration, including push notifications, dynamic destination resolving and all other Web and In-App Calls features..</param>
        /// <param name="displayName">Optional. A human-readable name for a given identity. Does not have to be unique. If set, it will be presented to all other users communicating with the identified user, along with identity. Must contain at least 5 and at most 50 characters..</param>
        /// <param name="capabilities">capabilities.</param>
        /// <param name="timeToLive">Optional. This field represents a number of seconds until the token expires. If not set, the token will last 8 hours. The maximum value is 24 hours..</param>
        public WebRtcTokenRequest(string identity = default, string applicationId = default, string displayName = default, WebRtcCapabilities capabilities = default, long timeToLive = default)
        {
            Identity = identity ?? throw new ArgumentNullException(nameof(identity));
            ApplicationId = applicationId;
            DisplayName = displayName;
            Capabilities = capabilities;
            TimeToLive = timeToLive;
        }

        /// <summary>
        /// The identity used to present user on Infobip WebRTC platform. Must be unique. Must contain at least 3 and at most 64 unicode characters including -, _, ..
        /// </summary>
        /// <value>The identity used to present user on Infobip WebRTC platform. Must be unique. Must contain at least 3 and at most 64 unicode characters including -, _, ..</value>
        [JsonProperty("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Application ID to be used for calls. Web and In-App application represents one-stop place for all your configuration, including push notifications, dynamic destination resolving and all other Web and In-App Calls features.
        /// </summary>
        /// <value>Application ID to be used for calls. Web and In-App application represents one-stop place for all your configuration, including push notifications, dynamic destination resolving and all other Web and In-App Calls features.</value>
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Optional. A human-readable name for a given identity. Does not have to be unique. If set, it will be presented to all other users communicating with the identified user, along with identity. Must contain at least 5 and at most 50 characters.
        /// </summary>
        /// <value>Optional. A human-readable name for a given identity. Does not have to be unique. If set, it will be presented to all other users communicating with the identified user, along with identity. Must contain at least 5 and at most 50 characters.</value>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Capabilities
        /// </summary>
        [JsonProperty("capabilities")]
        public WebRtcCapabilities Capabilities { get; set; }

        /// <summary>
        /// Optional. This field represents a number of seconds until the token expires. If not set, the token will last 8 hours. The maximum value is 24 hours.
        /// </summary>
        /// <value>Optional. This field represents a number of seconds until the token expires. If not set, the token will last 8 hours. The maximum value is 24 hours.</value>
        [JsonProperty("timeToLive")]
        [Range(0, 86400)]
        public long TimeToLive { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Identity (string) pattern
            var regexIdentity = new Regex(@"^[\p{L}\p{N}\-_+=/.]{3,64}$", RegexOptions.CultureInvariant);
            if (false == regexIdentity.Match(Identity).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for Identity, must match a pattern of {regexIdentity}", new[] { "Identity" });
            }

            // DisplayName (string)
            if (!string.IsNullOrEmpty(DisplayName) &&
                (DisplayName.Length < 5 || DisplayName.Length > 50))
            {
                yield return new ValidationResult("Invalid value for DisplayName, If set, must contain at least 5 and at most 50 characters.", new[] { "DisplayName" });
            }
        }
    }
}
