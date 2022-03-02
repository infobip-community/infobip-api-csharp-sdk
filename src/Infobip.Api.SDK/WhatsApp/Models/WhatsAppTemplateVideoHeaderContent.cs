using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateVideoHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class WhatsAppTemplateVideoHeaderContent : WhatsAppTemplateHeaderContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateVideoHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateVideoHeaderContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateVideoHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppTemplateVideoHeaderContent(string mediaUrl = default, string type = default) : base()
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.
        /// </summary>
        /// <value>URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.</value>
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