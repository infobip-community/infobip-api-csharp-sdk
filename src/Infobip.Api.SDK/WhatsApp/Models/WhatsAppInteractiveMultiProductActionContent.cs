using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message action.
    /// </summary>
    public class WhatsAppInteractiveMultiProductActionContent
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
        [Required(ErrorMessage = "MultiProduct Action CatalogId is required")]
        public string CatalogId { get; set; }

        /// <summary>
        /// An array of multi product sections.
        /// </summary>
        /// <value>An array of multi product sections.</value>
        [JsonProperty("sections")]
        [Required(ErrorMessage = "MultiProduct Action Sections property is required")]
        [MinLength(1)]
        [MaxLength(10)]
        public List<WhatsAppInteractiveMultiProductSectionContent> Sections { get; set; }
    }
}