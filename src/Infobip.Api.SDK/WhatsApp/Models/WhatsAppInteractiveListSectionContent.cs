using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Array of sections in the list.
    /// </summary>
    public class WhatsAppInteractiveListSectionContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListSectionContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveListSectionContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListSectionContent" /> class.
        /// </summary>
        /// <param name="title">Title of the section. Required if the message has more than one section..</param>
        /// <param name="rows">Array of rows sent in the section. Section must contain at least one row. Message can have up to ten rows. (required).</param>
        public WhatsAppInteractiveListSectionContent(string title = default, List<WhatsAppInteractiveRowContent> rows = default)
        {
            Rows = rows ?? throw new ArgumentNullException(nameof(rows));
            Title = title;
        }

        /// <summary>
        /// Title of the section. Required if the message has more than one section.
        /// </summary>
        /// <value>Title of the section. Required if the message has more than one section.</value>
        [JsonProperty("title")]
        [MinLength(1)]
        [MaxLength(24)]
        public string Title { get; set; }

        /// <summary>
        /// Array of rows sent in the section. Section must contain at least one row. Message can have up to ten rows.
        /// </summary>
        /// <value>Array of rows sent in the section. Section must contain at least one row. Message can have up to ten rows.</value>
        [JsonProperty("rows")]
        [Required(ErrorMessage = "List Section Rows property is required")]
        public List<WhatsAppInteractiveRowContent> Rows { get; set; }
    }
}