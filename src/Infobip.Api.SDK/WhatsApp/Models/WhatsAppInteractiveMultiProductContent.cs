using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppInteractiveMultiProductContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveMultiProductContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductContent" /> class.
        /// </summary>
        /// <param name="header">header (required).</param>
        /// <param name="body">body (required).</param>
        /// <param name="action">action (required).</param>
        /// <param name="footer">footer.</param>
        public WhatsAppInteractiveMultiProductContent(WhatsAppInteractiveMultiProductHeaderContent header = default, WhatsAppInteractiveBodyContent body = default, WhatsAppInteractiveMultiProductActionContent action = default, WhatsAppInteractiveFooterContent footer = default)
        {
            Header = header ?? throw new ArgumentNullException(nameof(header));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Footer = footer;
        }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [JsonProperty("header")]
        public WhatsAppInteractiveMultiProductHeaderContent Header { get; set; }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [JsonProperty("body")]
        public WhatsAppInteractiveBodyContent Body { get; set; }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [JsonProperty("action")]
        public WhatsAppInteractiveMultiProductActionContent Action { get; set; }

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