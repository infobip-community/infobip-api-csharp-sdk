using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Sets up tracking parameters to track conversion metrics and type.
    /// </summary>
    public class SmsTracking
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsTracking" /> class.
        /// </summary>
        /// <param name="baseUrl">Custom base URL for shortened links in messages when tracking URL conversions.</param>
        /// <param name="processKey">The process key which uniquely identifies conversion tracking.</param>
        /// <param name="track">Indicates if a message has to be tracked for conversion rates. Values are: SMS and URL.</param>
        /// <param name="type">Sets a custom conversion type naming convention, e.g. ONE_TIME_PIN or SOCIAL_INVITES.</param>
        public SmsTracking(string baseUrl = default, string processKey = default,
            string track = default, string type = default)
        {
            BaseUrl = baseUrl;
            ProcessKey = processKey;
            Track = track;
            Type = type;
        }

        /// <summary>
        /// Custom base URL for shortened links in messages when tracking URL conversions.
        /// </summary>
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// The process key which uniquely identifies conversion tracking.
        /// </summary>
        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        /// <summary>
        /// Indicates if a message has to be tracked for conversion rates. Values are: SMS and URL.
        /// </summary>
        [JsonProperty("track")]
        public string Track { get; set; }

        /// <summary>
        /// Sets a custom conversion type naming convention, e.g. ONE_TIME_PIN or SOCIAL_INVITES.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}