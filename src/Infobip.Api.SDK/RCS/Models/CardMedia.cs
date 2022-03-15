using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Object defining display of card media
    /// </summary>
    public class CardMedia
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardMedia" /> class.
        /// </summary>
        [JsonConstructor]
        protected CardMedia() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardMedia" /> class.
        /// </summary>
        /// <param name="file">file (required).</param>
        /// <param name="height">Height of the card media (required).</param>
        /// <param name="thumbnail">thumbnail.</param>
        public CardMedia(MessageResource file, CardMediaHeightEnum height, MessageResource thumbnail = default)
        {
            File = file ?? throw new ArgumentNullException(nameof(file));
            Height = height;
            Thumbnail = thumbnail;
        }

        /// <summary>
        /// Height of the card media
        /// </summary>
        /// <value>Height of the card media</value>
        [JsonProperty("height")]
        [Required(ErrorMessage = "Height is required")]
        public CardMediaHeightEnum Height { get; set; }

        /// <summary>
        /// Gets or Sets File
        /// </summary>
        [JsonProperty("file")]
        [Required(ErrorMessage = "File is required")]
        public MessageResource File { get; set; }

        /// <summary>
        /// Gets or Sets Thumbnail
        /// </summary>
        [JsonProperty("thumbnail")]
        public MessageResource Thumbnail { get; set; }
    }
}