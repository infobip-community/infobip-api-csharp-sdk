using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppAudioContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppAudioContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppAudioContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppAudioContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of an audio sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported audio types are &#x60;AAC&#x60;, &#x60;AMR&#x60;, &#x60;MP3&#x60;, &#x60;MP4&#x60;, &#x60;OPUS&#x60;. Maximum audio size is 16MB. (required).</param>
        public WhatsAppAudioContent(string mediaUrl = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of an audio sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported audio types are &#x60;AAC&#x60;, &#x60;AMR&#x60;, &#x60;MP3&#x60;, &#x60;MP4&#x60;, &#x60;OPUS&#x60;. Maximum audio size is 16MB.
        /// </summary>
        /// <value>URL of an audio sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported audio types are &#x60;AAC&#x60;, &#x60;AMR&#x60;, &#x60;MP3&#x60;, &#x60;MP4&#x60;, &#x60;OPUS&#x60;. Maximum audio size is 16MB.</value>
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