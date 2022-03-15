using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message action.
    /// </summary>
    public class WhatsAppInteractiveListActionContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListActionContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveListActionContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListActionContent" /> class.
        /// </summary>
        /// <param name="title">Title of the list. Does not allow emojis or markdown. (required).</param>
        /// <param name="sections">Array of sections in the list. (required).</param>
        public WhatsAppInteractiveListActionContent(string title = default, List<WhatsAppInteractiveListSectionContent> sections = default)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Sections = sections ?? throw new ArgumentNullException(nameof(sections));
        }

        /// <summary>
        /// Title of the list. Does not allow emojis or markdown.
        /// </summary>
        /// <value>Title of the list. Does not allow emojis or markdown.</value>
        [JsonProperty("title")]
        [Required(ErrorMessage = "List Action Title is required")]
        [MinLength(1)]
        [MaxLength(20)]
        public string Title { get; set; }

        /// <summary>
        /// Array of sections in the list.
        /// </summary>
        /// <value>Array of sections in the list.</value>
        [JsonProperty("sections")]
        [MinLength(1)]
        [MaxLength(10)]
        public List<WhatsAppInteractiveListSectionContent> Sections { get; set; }
    }
}