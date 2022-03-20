using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaVerificationStatusResponse
    /// </summary>
    public class TfaVerificationStatusResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaVerificationStatusResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public TfaVerificationStatusResponse() { }

        /// <summary>
        /// Collection of verifications
        /// </summary>
        [JsonProperty("verifications")]
        public List<TfaVerification> Verifications { get; set; }
    }
}
