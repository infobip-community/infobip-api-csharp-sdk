using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppImageContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppImageContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppImageContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppImageContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of an image sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB. (required).</param>
        /// <param name="caption">Caption of the image..</param>
        public WhatsAppImageContent(string mediaUrl = default, string caption = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Caption = caption;
        }

        /// <summary>
        /// URL of an image sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.
        /// </summary>
        /// <value>URL of an image sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.</value>
        [JsonProperty("mediaUrl")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Caption of the image.
        /// </summary>
        /// <value>Caption of the image.</value>
        [JsonProperty("caption")]
        public string Caption { get; set; }
        
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

            yield break;
        }
    }
}