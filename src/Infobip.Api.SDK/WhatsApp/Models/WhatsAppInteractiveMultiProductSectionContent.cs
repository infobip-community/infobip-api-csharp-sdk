using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// An array of multi product sections.
    /// </summary>
    public class WhatsAppInteractiveMultiProductSectionContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductSectionContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveMultiProductSectionContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductSectionContent" /> class.
        /// </summary>
        /// <param name="title">Title of the section. Required, if the message has more than one section..</param>
        /// <param name="productRetailerIds">An array of product-unique identifiers, as defined in catalog. If product retailer ID doesn&#39;t exist in your catalog, the product won&#39;t be displayed. (required).</param>
        public WhatsAppInteractiveMultiProductSectionContent(string title = default, List<string> productRetailerIds = default)
        {
            ProductRetailerIds = productRetailerIds ?? throw new ArgumentNullException(nameof(productRetailerIds));
            Title = title;
        }

        /// <summary>
        /// Title of the section. Required, if the message has more than one section.
        /// </summary>
        /// <value>Title of the section. Required, if the message has more than one section.</value>
        [JsonProperty("title")]
        [MinLength(0)]
        [MaxLength(24)]
        public string Title { get; set; }

        /// <summary>
        /// An array of product-unique identifiers, as defined in catalog. If product retailer ID doesn&#39;t exist in your catalog, the product won&#39;t be displayed.
        /// </summary>
        /// <value>An array of product-unique identifiers, as defined in catalog. If product retailer ID doesn&#39;t exist in your catalog, the product won&#39;t be displayed.</value>
        [JsonProperty("productRetailerIds")]
        [Required(ErrorMessage = "MultiProduct Section ProductRetailerIds property is required")]
        [MinLength(1)]
        public List<string> ProductRetailerIds { get; set; }
    }
}