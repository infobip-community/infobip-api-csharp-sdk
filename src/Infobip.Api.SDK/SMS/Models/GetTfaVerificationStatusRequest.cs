using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaVerificationStatusRequest
    /// </summary>
    public class TfaVerificationStatusRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaVerificationStatusRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected TfaVerificationStatusRequest() { }

        /// <summary>
        /// Filter by msisdn (phone number) for which verification status is checked.
        /// </summary>
        [JsonProperty("msisdn")]
        [Required]
        public string Msisdn { get; set; }

        /// <summary>
        /// Filter by verified (true or false).
        /// </summary>
        [JsonProperty("verified")]
        [Required]
        public bool Verified { get; set; }

        /// <summary>
        /// Filter by message sent status (true or false).
        /// </summary>
        [JsonProperty("sent")]
        [Required]
        public bool Sent { get; set; }
    }
}
