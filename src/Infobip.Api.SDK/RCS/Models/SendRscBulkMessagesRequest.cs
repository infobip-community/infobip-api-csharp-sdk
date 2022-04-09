using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// SendRscBulkMessagesRequest
    /// </summary>
    public class SendRscBulkMessagesRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendRscBulkMessagesRequest" /> class.
        /// </summary>
        /// <param name="messages">messages.</param>
        public SendRscBulkMessagesRequest(List<SendRcsMessageRequest> messages = default)
        {
            Messages = messages;
        }

        /// <summary>
        /// Gets or Sets Messages
        /// </summary>
        [JsonProperty("messages")]
        public List<SendRcsMessageRequest> Messages { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Messages == null || Messages.Count < 1)
            {
                yield return new ValidationResult(
                    $"Invalid value for {nameof(Messages)}, must be at least one element.",
                    new[] { nameof(Messages) });
            }
        }
    }
}
