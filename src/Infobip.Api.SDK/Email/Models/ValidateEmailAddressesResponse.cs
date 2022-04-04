using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// ValidateEmailAddressesResponse
    /// </summary>
    public class ValidateEmailAddressesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateEmailAddressesResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public ValidateEmailAddressesResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateEmailAddressesResponse" /> class.
        /// </summary>
        /// <param name="catchAll">catchAll.</param>
        /// <param name="didYouMean">didYouMean.</param>
        /// <param name="disposable">disposable.</param>
        /// <param name="roleBased">roleBased.</param>
        /// <param name="to">to.</param>
        /// <param name="validMailbox">validMailbox.</param>
        /// <param name="validSyntax">validSyntax.</param>
        public ValidateEmailAddressesResponse(bool catchAll = default, string didYouMean = default, bool disposable = default, bool roleBased = default, string to = default, string validMailbox = default, bool validSyntax = default)
        {
            CatchAll = catchAll;
            DidYouMean = didYouMean;
            Disposable = disposable;
            RoleBased = roleBased;
            To = to;
            ValidMailbox = validMailbox;
            ValidSyntax = validSyntax;
        }

        /// <summary>
        /// Gets or Sets CatchAll
        /// </summary>
        [JsonProperty("catchAll")]
        public bool CatchAll { get; set; }

        /// <summary>
        /// Gets or Sets DidYouMean
        /// </summary>
        [JsonProperty("didYouMean")]
        public string DidYouMean { get; set; }

        /// <summary>
        /// Gets or Sets Disposable
        /// </summary>
        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        /// <summary>
        /// Gets or Sets RoleBased
        /// </summary>
        [JsonProperty("roleBased")]
        public bool RoleBased { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets ValidMailbox
        /// </summary>
        [JsonProperty("validMailbox")]
        public string ValidMailbox { get; set; }

        /// <summary>
        /// Gets or Sets ValidSyntax
        /// </summary>
        [JsonProperty("validSyntax")]
        public bool ValidSyntax { get; set; }
    }
}