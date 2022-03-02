using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// SendRcsMessageMessageTypeFileContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeFileContent : MessageTypeContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeFileContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageTypeFileContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeFileContent" /> class.
        /// </summary>
        /// <param name="file">file (required).</param>
        /// <param name="thumbnail">thumbnail.</param>
        /// <param name="type">Message type, describing type of message which is going to be sent over RCS.</param>
        public MessageTypeFileContent(MessageResource file = default, MessageResource thumbnail = default, TypeEnum? type = default)
        {
            File = file ?? throw new ArgumentNullException(nameof(file));
            Thumbnail = thumbnail;
        }

        /// <summary>
        /// Gets or Sets File
        /// </summary>
        [JsonProperty("file")]
        public MessageResource File { get; set; }

        /// <summary>
        /// Gets or Sets Thumbnail
        /// </summary>
        [JsonProperty("thumbnail")]
        public MessageResource Thumbnail { get; set; }

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
        }
    }
}