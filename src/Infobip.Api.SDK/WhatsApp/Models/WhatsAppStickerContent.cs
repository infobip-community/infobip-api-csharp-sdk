using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppStickerContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppStickerContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppStickerContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppStickerContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a sticker sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported sticker type is &#x60;WebP&#x60;. Sticker file should be 512x512 pixels. Maximum sticker size is 100KB. (required).</param>
        public WhatsAppStickerContent(string mediaUrl = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of a sticker sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported sticker type is &#x60;WebP&#x60;. Sticker file should be 512x512 pixels. Maximum sticker size is 100KB.
        /// </summary>
        /// <value>URL of a sticker sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported sticker type is &#x60;WebP&#x60;. Sticker file should be 512x512 pixels. Maximum sticker size is 100KB.</value>
        [JsonProperty("mediaUrl")]
        public string MediaUrl { get; set; }
        
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

            yield break;
        }
    }
}