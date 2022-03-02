using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Rcs message contents
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCardContent), "CARD")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeCarouselContent), "CAROUSEL")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeFileContent), "FILE")]
    [JsonSubtypes.KnownSubType(typeof(MessageTypeTextContent), "TEXT")]
    public class MessageTypeContent : IValidatableObject
    {
        /// <summary>
        /// Message type, describing type of message which is going to be sent over RCS
        /// </summary>
        /// <value>Message type, describing type of message which is going to be sent over RCS</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum TEXT for value: TEXT
            /// </summary>
            [EnumMember(Value = "TEXT")]
            TEXT = 1,

            /// <summary>
            /// Enum FILE for value: FILE
            /// </summary>
            [EnumMember(Value = "FILE")]
            FILE = 2,

            /// <summary>
            /// Enum CARD for value: CARD
            /// </summary>
            [EnumMember(Value = "CARD")]
            CARD = 3,

            /// <summary>
            /// Enum CAROUSEL for value: CAROUSEL
            /// </summary>
            [EnumMember(Value = "CAROUSEL")]
            CAROUSEL = 4

        }


        /// <summary>
        /// Message type, describing type of message which is going to be sent over RCS
        /// </summary>
        /// <value>Message type, describing type of message which is going to be sent over RCS</value>
        [JsonProperty("type")]
        public TypeEnum? Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeContent" /> class.
        /// </summary>
        /// <param name="type">Message type, describing type of message which is going to be sent over RCS.</param>
        public MessageTypeContent(TypeEnum? type = default)
        {
            Type = type;
        }

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
            yield break;
        }
    }
}