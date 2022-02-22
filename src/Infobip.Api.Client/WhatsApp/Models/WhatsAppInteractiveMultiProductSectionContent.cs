using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// An array of multi product sections.
    /// </summary>
    public class WhatsAppInteractiveMultiProductSectionContent : IValidatableObject
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
        public string Title { get; set; }

        /// <summary>
        /// An array of product-unique identifiers, as defined in catalog. If product retailer ID doesn&#39;t exist in your catalog, the product won&#39;t be displayed.
        /// </summary>
        /// <value>An array of product-unique identifiers, as defined in catalog. If product retailer ID doesn&#39;t exist in your catalog, the product won&#39;t be displayed.</value>
        [JsonProperty("productRetailerIds")]
        public List<string> ProductRetailerIds { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Title (string) maxLength
            if (Title != null && Title.Length > 24)
            {
                yield return new ValidationResult("Invalid value for Title, length must be less than 24.", new[] { "Title" });
            }

            // Title (string) minLength
            if (Title != null && Title.Length < 0)
            {
                yield return new ValidationResult("Invalid value for Title, length must be greater than 0.", new[] { "Title" });
            }

            yield break;
        }
    }
}