using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaVerification
    /// </summary>
    public class TfaVerification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaVerification" /> class.
        /// </summary>
        [JsonConstructor]
        public TfaVerification()
        {
        }

        /// <summary>
        /// Phone number (MSISDN) for which verification status is checked.
        /// </summary>
        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Sent UNIX timestamp (in millis), if the phone number (MSISDN) is verified.
        /// </summary>
        [JsonProperty("sentAt")]
        public long SentAt { get; set; }

        /// <summary>
        /// Indicates if the phone number (MSISDN) is already verified for 2FA application with given ID.
        /// </summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        /// <summary>
        /// Verification UNIX timestamp (in millis), if the phone number (MSISDN) is verified.
        /// </summary>
        [JsonProperty("verifiedAt")]
        public long VerifiedAt { get; set; }
    }
}