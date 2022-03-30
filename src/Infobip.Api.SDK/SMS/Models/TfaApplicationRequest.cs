using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaApplicationRequest
    /// </summary>
    public class TfaApplicationRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaApplicationRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected TfaApplicationRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TfaApplicationRequest" /> class.
        /// </summary>
        /// <param name="name">2FA application name. (required).</param>
        /// <param name="enabled">Indicates if the created application is enabled.</param>
        /// <param name="configuration">Created 2FA application configuration.</param>
        public TfaApplicationRequest(string name, bool enabled = default, TfaApplicationConfiguration configuration = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Configuration = configuration;
            Enabled = enabled;
        }

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
        [Required]
        public string Name { get; set; }
    }
}
