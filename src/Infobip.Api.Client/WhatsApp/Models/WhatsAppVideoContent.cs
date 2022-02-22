using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppVideoContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppVideoContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppVideoContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppVideoContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a video sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB. (required).</param>
        /// <param name="caption">Caption of the video..</param>
        public WhatsAppVideoContent(string mediaUrl = default, string caption = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Caption = caption;
        }

        /// <summary>
        /// URL of a video sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.
        /// </summary>
        /// <value>URL of a video sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.</value>
        [JsonProperty("mediaUrl")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Caption of the video.
        /// </summary>
        /// <value>Caption of the video.</value>
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