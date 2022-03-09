using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// An array of cards contained within the carousel
    /// </summary>
    public class CardContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardContent" /> class.
        /// </summary>
        /// <param name="title">Title of the card, displayed as bolded text.</param>
        /// <param name="description">Description of the card, displayed as regular text.</param>
        /// <param name="media">media.</param>
        /// <param name="suggestions">List of suggestions that will be sent in card.</param>
        public CardContent(string title = default, string description = default, CardMedia media = default, List<Suggestion> suggestions = default)
        {
            Title = title;
            Description = description;
            Media = media;
            Suggestions = suggestions;
        }

        /// <summary>
        /// Title of the card, displayed as bolded text
        /// </summary>
        /// <value>Title of the card, displayed as bolded text</value>
        [JsonProperty("title")]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; }

        /// <summary>
        /// Description of the card, displayed as regular text
        /// </summary>
        /// <value>Description of the card, displayed as regular text</value>
        [JsonProperty("description")]
        [StringLength(2000, MinimumLength = 1)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Media
        /// </summary>
        [JsonProperty("media")]
        public CardMedia Media { get; set; }

        /// <summary>
        /// List of suggestions that will be sent in card
        /// </summary>
        /// <value>List of suggestions that will be sent in card</value>
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
}