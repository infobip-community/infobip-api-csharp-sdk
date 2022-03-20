using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// ValidateEmailAddressesRequest
    /// </summary>
    public class ValidateEmailAddressesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateEmailAddressesRequest" /> class.
        /// </summary>
        [JsonConstructor]
        public ValidateEmailAddressesRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateEmailAddressesResponse" /> class.
        /// </summary>
        /// <param name="to">Email address of the recipient.</param>
        public ValidateEmailAddressesRequest(string to)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
        }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [JsonProperty("to")]
        [Required]
        [MinLength(1)]
        [MaxLength(int.MaxValue)]
        public string To { get; set; }
    }
}
