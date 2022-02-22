using Newtonsoft.Json;

namespace Infobip.Api.Client.WebRtc.Models
{
    /// <summary>
    /// Configuration used to enable iOS push notifications.
    /// </summary>
    public class IosApplicationPushNotificationConfig
    {
        /// <summary>
        /// Name of the APNS certificate file used to enable iOS push notifications.
        /// </summary>
        /// <value>Name of the APNS certificate file used to enable iOS push notifications.</value>
        [JsonProperty("apnsCertificateFileName")]
        public string ApnsCertificateFileName { get; set; }

        /// <summary>
        /// Content of the APNS certificate file used to enable iOS push notifications.
        /// </summary>
        /// <value>Content of the APNS certificate file used to enable iOS push notifications.</value>
        [JsonProperty("apnsCertificateFileContent")]
        public string ApnsCertificateFileContent { get; set; }

        /// <summary>
        /// Password used for decryption of the APNS certificate.
        /// </summary>
        /// <value>Password used for decryption of the APNS certificate.</value>
        [JsonProperty("apnsCertificatePassword")]
        public string ApnsCertificatePassword { get; set; }

    }
}