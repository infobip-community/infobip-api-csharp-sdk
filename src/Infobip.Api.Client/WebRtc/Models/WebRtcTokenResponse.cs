using Newtonsoft.Json;

namespace Infobip.Api.Client.WebRtc.Models
{
    /// <summary>
    /// WebRtcTokenResponse
    /// </summary>
    public class WebRtcTokenResponse
    {
        [JsonConstructor]
        public WebRtcTokenResponse() { }

        /// <summary>
        /// The access token used to connect client SDKs to Infobip WebRTC platform.
        /// </summary>
        /// <value>The access token used to connect client SDKs to Infobip WebRTC platform.</value>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Time point until which token is valid. The default value is 8h. If it expires, the user must be provided with the new valid token in order to continue using Infobip WebRTC platform. There is no notification about token expiry, you must track that by yourself.
        /// </summary>
        /// <value>Time point until which token is valid. The default value is 8h. If it expires, the user must be provided with the new valid token in order to continue using Infobip WebRTC platform. There is no notification about token expiry, you must track that by yourself.</value>
        [JsonProperty("expirationTime")]
        public string ExpirationTime { get; set; }
    }
}