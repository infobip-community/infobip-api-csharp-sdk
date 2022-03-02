using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppInteractiveButtonsContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsContent" /> class.
        /// </summary>
        /// <param name="body">body (required).</param>
        /// <param name="action">action (required).</param>
        /// <param name="header">header.</param>
        /// <param name="footer">footer.</param>
        public WhatsAppInteractiveButtonsContent(WhatsAppInteractiveBodyContent body = default, WhatsAppInteractiveButtonsActionContent action = default, WhatsAppInteractiveButtonsHeaderContent header = default, WhatsAppInteractiveFooterContent footer = default)
        {
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Header = header;
            Footer = footer;
        }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [JsonProperty("body")]
        public WhatsAppInteractiveBodyContent Body { get; set; }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [JsonProperty("action")]
        public WhatsAppInteractiveButtonsActionContent Action { get; set; }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [JsonProperty("header")]
        public WhatsAppInteractiveButtonsHeaderContent Header { get; set; }

        /// <summary>
        /// Gets or Sets Footer
        /// </summary>
        [JsonProperty("footer")]
        public WhatsAppInteractiveFooterContent Footer { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}