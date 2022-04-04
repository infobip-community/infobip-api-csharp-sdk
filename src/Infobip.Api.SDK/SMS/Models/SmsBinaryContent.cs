using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsBinaryContent
    /// </summary>
    public class SmsBinaryContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsBinaryContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsBinaryContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsBinaryContent" /> class.
        /// </summary>
        /// <param name="dataCoding">Binary content data coding. The default value is (0) for GSM7. Example: (8) for Unicode data.</param>
        /// <param name="esmClass">"Esm_class" parameter. Indicate special message attributes associated with the SMS. Default value is (0).</param>
        /// <param name="hex">Hexadecimal string. This is the representation of your binary data. Two hex digits represent one byte. They should be separated by the space character (Example: 0f c2 4a bf 34 13 ba).</param>
        public SmsBinaryContent(int dataCoding = default, int esmClass = default, string hex = default)
        {
            Hex = hex ?? throw new ArgumentNullException(nameof(hex));
            DataCoding = dataCoding;
            EsmClass = esmClass;
        }

        /// <summary>
        /// Binary content data coding. The default value is (0) for GSM7. Example: (8) for Unicode data.
        /// </summary>
        [JsonProperty("dataCoding")]
        public int DataCoding { get; set; }

        /// <summary>
        /// "Esm_class" parameter. Indicate special message attributes associated with the SMS. Default value is (0).
        /// </summary>
        [JsonProperty("esmClass")]
        public int EsmClass { get; set; }

        /// <summary>
        /// Hexadecimal string. This is the representation of your binary data. Two hex digits represent one byte. They should
        /// be separated by the space character (Example: &#x60;0f c2 4a bf 34 13 ba&#x60;).
        /// </summary>
        /// <value>
        /// Hexadecimal string. This is the representation of your binary data. Two hex digits represent one byte. They
        /// should be separated by the space character (Example: &#x60;0f c2 4a bf 34 13 ba&#x60;).
        /// </value>
        [JsonProperty("hex")]
        [Required]
        public string Hex { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //
            // Hex (string) pattern
            var regexHex = new Regex(@"^(?:^|\s)([0-9a-fA-F]{2}(?:\s|$))+$", RegexOptions.CultureInvariant);
            if (false == regexHex.Match(Hex).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for Hex, must match a pattern of {regexHex}", new[] { nameof(Hex) });
            }
        }
    }
}