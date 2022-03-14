using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WebRtc.Models
{
    /// <summary>
    /// WebRtcApplicationRequest
    /// </summary>
    public class WebRtcApplicationRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebRtcApplicationRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected WebRtcApplicationRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRtcApplicationRequest" /> class.
        /// </summary>
        /// <param name="name">Application name (required).</param>
        /// <param name="description">Application description containing up to 160 characters..</param>
        /// <param name="ios">ios.</param>
        /// <param name="android">android.</param>
        /// <param name="appToApp">Enable to communicate app to app. (default to false).</param>
        /// <param name="appToConversations">Enable to forward incoming calls to an agent on Conversations platform. (default to false).</param>
        /// <param name="appToPhone">Enable to forward incoming calls to a phone number. (default to false).</param>
        public WebRtcApplicationRequest(string name = default, string description = default, IosApplicationPushNotificationConfig ios = default, AndroidApplicationPushNotificationConfig android = default, bool appToApp = false, bool appToConversations = false, bool appToPhone = false)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            Ios = ios;
            Android = android;
            AppToApp = appToApp;
            AppToConversations = appToConversations;
            AppToPhone = appToPhone;
        }

        /// <summary>
        /// Application name
        /// </summary>
        /// <value>Application name</value>
        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Application description containing up to 160 characters.
        /// </summary>
        /// <value>Application description containing up to 160 characters.</value>
        [JsonProperty("description")]
        [MaxLength(160)]
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
