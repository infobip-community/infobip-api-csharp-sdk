using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WebRtc.Models
{
    /// <summary>
    /// Configuration used to enable Android push notifications.
    /// </summary>
    public class AndroidApplicationPushNotificationConfig
    {
        /// <summary>
        /// FCM Server Key used to enable Android push notifications.
        /// </summary>
        /// <value>FCM Server Key used to enable Android push notifications.</value>
        [JsonProperty("fcmServerKey")]
        [Required(ErrorMessage = "FcmServerKey is required")]
        public string FcmServerKey { get; set; }
        
    }
}