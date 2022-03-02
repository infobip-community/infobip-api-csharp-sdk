using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppContactsContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppContactsContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppContactsContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppContactsContent" /> class.
        /// </summary>
        /// <param name="contacts">An array of contacts sent in a WhatsApp message. (required).</param>
        public WhatsAppContactsContent(List<WhatsAppContactContent> contacts = default)
        {
            Contacts = contacts ?? throw new ArgumentNullException(nameof(contacts));
        }

        /// <summary>
        /// An array of contacts sent in a WhatsApp message.
        /// </summary>
        /// <value>An array of contacts sent in a WhatsApp message.</value>
        [JsonProperty("contacts")]
        public List<WhatsAppContactContent> Contacts { get; set; }
        
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