using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// VerifyPhoneNumberRequest
    /// </summary>
    public class VerifyPhoneNumberRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerifyPhoneNumberRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected VerifyPhoneNumberRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerifyPhoneNumberRequest" /> class.
        /// </summary>
        /// <param name="pin">The PIN code to verify.</param>
        public VerifyPhoneNumberRequest(string pin = default)
        {
            Pin = pin ?? throw new ArgumentNullException(nameof(pin));
        }

        /// <summary>
        /// PIN code to verify
        /// </summary>
        [JsonProperty("pin")]
        [Required]
        public string Pin { get; set; }
    }
}
