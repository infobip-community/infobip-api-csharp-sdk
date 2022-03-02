using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveButtonsImageHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsVideoHeaderContent), "VIDEO")]
    public class WhatsAppInteractiveButtonsImageHeaderContent : WhatsAppInteractiveButtonsHeaderContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsImageHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsImageHeaderContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsImageHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppInteractiveButtonsImageHeaderContent(string mediaUrl = default, string type = default) : base()
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.
        /// </summary>
        /// <value>URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.</value>
        [JsonProperty("mediaUrl")]
        public string MediaUrl { get; set; }
        
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

            yield break;
        }
    }
}