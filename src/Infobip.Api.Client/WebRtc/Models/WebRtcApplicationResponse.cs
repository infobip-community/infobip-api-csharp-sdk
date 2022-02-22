using Newtonsoft.Json;

namespace Infobip.Api.Client.WebRtc.Models
{
    /// <summary>
    /// WebRtcApplicationResponse
    /// </summary>
    public class WebRtcApplicationResponse
    {
        /// <summary>
        /// Application identifier
        /// </summary>
        /// <value>Application identifier</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Application name
        /// </summary>
        /// <value>Application name</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Application description containing up to 160 characters.
        /// </summary>
        /// <value>Application description containing up to 160 characters.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Ios
        /// </summary>
        [JsonProperty("ios")]
        public IosApplicationPushNotificationConfig Ios { get; set; }

        /// <summary>
        /// Gets or Sets Android
        /// </summary>
        [JsonProperty("android")]
        public AndroidApplicationPushNotificationConfig Android { get; set; }

        /// <summary>
        /// Enable to communicate app to app.
        /// </summary>
        /// <value>Enable to communicate app to app.</value>
        [JsonProperty("appToApp")]
        public bool AppToApp { get; set; }

        /// <summary>
        /// Enable to forward incoming calls to an agent on Conversations platform.
        /// </summary>
        /// <value>Enable to forward incoming calls to an agent on Conversations platform.</value>
        [JsonProperty("appToConversations")]
        public bool AppToConversations { get; set; }

        /// <summary>
        /// Enable to forward incoming calls to a phone number.
        /// </summary>
        /// <value>Enable to forward incoming calls to a phone number.</value>
        [JsonProperty("appToPhone")]
        public bool AppToPhone { get; set; }
    }
}
