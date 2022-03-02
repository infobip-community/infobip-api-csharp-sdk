using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveButtonsDocumentHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsVideoHeaderContent), "VIDEO")]
    public class WhatsAppInteractiveButtonsDocumentHeaderContent : WhatsAppInteractiveButtonsHeaderContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsDocumentHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsDocumentHeaderContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsDocumentHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB. (required).</param>
        /// <param name="filename">Filename of the document..</param>
        /// <param name="type">type (required).</param>
        public WhatsAppInteractiveButtonsDocumentHeaderContent(string mediaUrl = default, string filename = default, string type = default) : base()
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Filename = filename;
        }

        /// <summary>
        /// URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB.
        /// </summary>
        /// <value>URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB.</value>
        [JsonProperty("mediaUrl")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Filename of the document.
        /// </summary>
        /// <value>Filename of the document.</value>
        [JsonProperty("filename")]
        public string Filename { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in BaseValidate(validationContext))
            {
                yield return x;
            }
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