using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Array of rows sent in the section. Section must contain at least one row. Message can have up to ten rows.
    /// </summary>
    public class WhatsAppInteractiveRowContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveRowContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveRowContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveRowContent" /> class.
        /// </summary>
        /// <param name="id">Identifier of the row. It must be unique across all sections. (required).</param>
        /// <param name="title">Title of the row. (required).</param>
        /// <param name="description">Description of the row..</param>
        public WhatsAppInteractiveRowContent(string id = default, string title = default, string description = default)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description;
        }

        /// <summary>
        /// Identifier of the row. It must be unique across all sections.
        /// </summary>
        /// <value>Identifier of the row. It must be unique across all sections.</value>
        [JsonProperty("id")]
        [Required(ErrorMessage = "Row Id is required")]
        [MinLength(1)]
        [MaxLength(200)]
        public string Id { get; set; }

        /// <summary>
        /// Title of the row.
        /// </summary>
        /// <value>Title of the row.</value>
        [JsonProperty("title")]
        [Required(ErrorMessage = "Row Title is required")]
        [MinLength(1)]
        [MaxLength(24)]
        public string Title { get; set; }

        /// <summary>
        /// Description of the row.
        /// </summary>
        /// <value>Description of the row.</value>
        [JsonProperty("description")]
        [MinLength(0)]
        [MaxLength(72)]
        public string Description { get; set; }
    }
}