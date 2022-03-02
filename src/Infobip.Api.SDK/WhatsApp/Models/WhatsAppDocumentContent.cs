using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppDocumentContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppDocumentContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppDocumentContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppDocumentContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a document sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Maximum document size is 100MB. (required).</param>
        /// <param name="caption">Caption of the document..</param>
        /// <param name="filename">File name of the document..</param>
        public WhatsAppDocumentContent(string mediaUrl = default, string caption = default, string filename = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Caption = caption;
            Filename = filename;
        }

        /// <summary>
        /// URL of a document sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Maximum document size is 100MB.
        /// </summary>
        /// <value>URL of a document sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Maximum document size is 100MB.</value>
        [JsonProperty("mediaUrl")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Caption of the document.
        /// </summary>
        /// <value>Caption of the document.</value>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// File name of the document.
        /// </summary>
        /// <value>File name of the document.</value>
        [JsonProperty("filename")]
        public string Filename { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // MediaUrl (string) maxLength
            if (MediaUrl != null && MediaUrl.Length > 2048)
            {
                yield return new ValidationResult("Invalid value for MediaUrl, length must be less than 2048.", new[] { "MediaUrl" });
            }

            // MediaUrl (string) minLength
            if (MediaUrl != null && MediaUrl.Length < 1)
            {
                yield return new ValidationResult("Invalid value for MediaUrl, length must be greater than 1.", new[] { "MediaUrl" });
            }

            // Caption (string) maxLength
            if (Caption != null && Caption.Length > 3000)
            {
                yield return new ValidationResult("Invalid value for Caption, length must be less than 3000.", new[] { "Caption" });
            }

            // Caption (string) minLength
            if (Caption != null && Caption.Length < 0)
            {
                yield return new ValidationResult("Invalid value for Caption, length must be greater than 0.", new[] { "Caption" });
            }

            // Filename (string) maxLength
            if (Filename != null && Filename.Length > 240)
            {
                yield return new ValidationResult("Invalid value for Filename, length must be less than 240.", new[] { "Filename" });
            }

            // Filename (string) minLength
            if (Filename != null && Filename.Length < 0)
            {
                yield return new ValidationResult("Invalid value for Filename, length must be greater than 0.", new[] { "Filename" });
            }

            yield break;
        }
    }
}