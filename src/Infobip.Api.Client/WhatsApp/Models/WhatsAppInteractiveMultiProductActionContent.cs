using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// Message action.
    /// </summary>
    public class WhatsAppInteractiveMultiProductActionContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductActionContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveMultiProductActionContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductActionContent" /> class.
        /// </summary>
        /// <param name="catalogId">The ID that uniquely identifies the catalog registered with Facebook, connected to the WhatsApp Business Account (WABA) the sender belongs to. (required).</param>
        /// <param name="sections">An array of multi product sections. (required).</param>
        public WhatsAppInteractiveMultiProductActionContent(string catalogId = default, List<WhatsAppInteractiveMultiProductSectionContent> sections = default)
        {
            CatalogId = catalogId ?? throw new ArgumentNullException(nameof(catalogId));
            Sections = sections ?? throw new ArgumentNullException(nameof(sections));
        }

        /// <summary>
        /// The ID that uniquely identifies the catalog registered with Facebook, connected to the WhatsApp Business Account (WABA) the sender belongs to.
        /// </summary>
        /// <value>The ID that uniquely identifies the catalog registered with Facebook, connected to the WhatsApp Business Account (WABA) the sender belongs to.</value>
        [JsonProperty("catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// An array of multi product sections.
        /// </summary>
        /// <value>An array of multi product sections.</value>
        [JsonProperty("sections")]
        public List<WhatsAppInteractiveMultiProductSectionContent> Sections { get; set; }
        
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