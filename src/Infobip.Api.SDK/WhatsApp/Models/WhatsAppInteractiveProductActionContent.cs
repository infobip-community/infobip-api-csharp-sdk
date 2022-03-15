using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message action.
    /// </summary>
    public class WhatsAppInteractiveProductActionContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveProductActionContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveProductActionContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveProductActionContent" /> class.
        /// </summary>
        /// <param name="catalogId">The ID that uniquely identifies the catalog registered with Facebook, connected to the WhatsApp Business Account (WABA) the sender belongs to. (required).</param>
        /// <param name="productRetailerId">Product-unique identifier, as defined in catalog. (required).</param>
        public WhatsAppInteractiveProductActionContent(string catalogId = default, string productRetailerId = default)
        {
            CatalogId = catalogId ?? throw new ArgumentNullException(nameof(catalogId));
            ProductRetailerId = productRetailerId ?? throw new ArgumentNullException(nameof(productRetailerId));
        }

        /// <summary>
        /// The ID that uniquely identifies the catalog registered with Facebook, connected to the WhatsApp Business Account (WABA) the sender belongs to.
        /// </summary>
        /// <value>The ID that uniquely identifies the catalog registered with Facebook, connected to the WhatsApp Business Account (WABA) the sender belongs to.</value>
        [JsonProperty("catalogId")]
        [Required(ErrorMessage = "CatalogId is required")]
        public string CatalogId { get; set; }

        /// <summary>
        /// Product-unique identifier, as defined in catalog.
        /// </summary>
        /// <value>Product-unique identifier, as defined in catalog.</value>
        [JsonProperty("productRetailerId")]
        [Required(ErrorMessage = "ProductRetailerId is required")]
        public string ProductRetailerId { get; set; }
    }
}