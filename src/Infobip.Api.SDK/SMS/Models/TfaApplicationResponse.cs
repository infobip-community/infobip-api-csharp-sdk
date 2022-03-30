using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaApplicationResponse
    /// </summary>
    public class TfaApplicationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaApplicationResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public TfaApplicationResponse() { }

        /// <summary>
        /// 2FA application ID.
        /// </summary>
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Created 2FA application configuration.
        /// </summary>
        [JsonProperty("configuration")]
        public TfaApplicationConfiguration Configuration { get; set; }

        /// <summary>
        /// Indicates if the created application is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 2FA application name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
