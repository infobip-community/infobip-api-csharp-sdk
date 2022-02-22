using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// An array of contacts sent in a WhatsApp message.
    /// </summary>
    public class WhatsAppContactContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppContactContent" /> class.
        /// </summary>
        [JsonConstructor]
        public WhatsAppContactContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppContactContent" /> class.
        /// </summary>
        /// <param name="addresses">Array of addresses information..</param>
        /// <param name="birthday">Date of birth in &#x60;YYYY-MM-DD&#x60; format..</param>
        /// <param name="emails">Array of emails information..</param>
        /// <param name="name">name (required).</param>
        /// <param name="org">org.</param>
        /// <param name="phones">Array of phones information..</param>
        /// <param name="urls">Array of urls information..</param>
        public WhatsAppContactContent(List<WhatsAppAddressContent> addresses = default, string birthday = default, List<WhatsAppEmailContent> emails = default, WhatsAppNameContent name = default, WhatsAppOrganizationContent org = default, List<WhatsAppPhoneContent> phones = default, List<WhatsAppUrlContent> urls = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Addresses = addresses;
            Birthday = birthday;
            Emails = emails;
            Org = org;
            Phones = phones;
            Urls = urls;
        }

        /// <summary>
        /// Array of addresses information.
        /// </summary>
        /// <value>Array of addresses information.</value>
        [JsonProperty("addresses")]
        public List<WhatsAppAddressContent> Addresses { get; set; }

        /// <summary>
        /// Date of birth in &#x60;YYYY-MM-DD&#x60; format.
        /// </summary>
        /// <value>Date of birth in &#x60;YYYY-MM-DD&#x60; format.</value>
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// Array of emails information.
        /// </summary>
        /// <value>Array of emails information.</value>
        [JsonProperty("emails")]
        public List<WhatsAppEmailContent> Emails { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty("name")]
        public WhatsAppNameContent Name { get; set; }

        /// <summary>
        /// Gets or Sets Org
        /// </summary>
        [JsonProperty("org")]
        public WhatsAppOrganizationContent Org { get; set; }

        /// <summary>
        /// Array of phones information.
        /// </summary>
        /// <value>Array of phones information.</value>
        [JsonProperty("phones")]
        public List<WhatsAppPhoneContent> Phones { get; set; }

        /// <summary>
        /// Array of urls information.
        /// </summary>
        /// <value>Array of urls information.</value>
        [JsonProperty("urls")]
        public List<WhatsAppUrlContent> Urls { get; set; }
        
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