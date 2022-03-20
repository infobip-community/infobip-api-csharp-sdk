using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// VerifyPhoneNumberResponse
    /// </summary>
    public class VerifyPhoneNumberResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerifyPhoneNumberResponse" /> class.
        /// </summary>
        [JsonConstructor]
        protected VerifyPhoneNumberResponse() { }

        /// <summary>
        /// Number of remaining PIN attempts.
        /// </summary>
        [JsonProperty("attemptsRemaining")]
        public int AttemptsRemaining { get; set; }

        /// <summary>
        /// Phone number (MSISDN) to which the 2FA message was sent.
        /// </summary>
        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Indicates whether an error has occurred during PIN verification.
        /// </summary>
        [JsonProperty("pinError")]
        public string PinError { get; set; }

        /// <summary>
        /// Sent PIN code ID.
        /// </summary>
        [JsonProperty("pinId")]
        public string PinId { get; set; }

        /// <summary>
        /// Indicates whether the phone number (MSISDN) was successfully verified.
        /// </summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; }
    }
}
