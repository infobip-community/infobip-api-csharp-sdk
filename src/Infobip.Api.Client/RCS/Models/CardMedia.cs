using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.Client.RCS.Models
{
    /// <summary>
    /// Object defining display of card media
    /// </summary>
    public class CardMedia : IValidatableObject
    {
        /// <summary>
        /// Height of the card media
        /// </summary>
        /// <value>Height of the card media</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum HeightEnum
        {
            /// <summary>
            /// Enum SHORT for value: SHORT
            /// </summary>
            [EnumMember(Value = "SHORT")]
            SHORT = 1,

            /// <summary>
            /// Enum MEDIUM for value: MEDIUM
            /// </summary>
            [EnumMember(Value = "MEDIUM")]
            MEDIUM = 2,

            /// <summary>
            /// Enum TALL for value: TALL
            /// </summary>
            [EnumMember(Value = "TALL")]
            TALL = 3

        }


        /// <summary>
        /// Height of the card media
        /// </summary>
        /// <value>Height of the card media</value>
        [JsonProperty("height")]
        public HeightEnum Height { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CardMedia" /> class.
        /// </summary>
        [JsonConstructor]
        protected CardMedia() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CardMedia" /> class.
        /// </summary>
        /// <param name="file">file (required).</param>
        /// <param name="thumbnail">thumbnail.</param>
        /// <param name="height">Height of the card media (required).</param>
        public CardMedia(MessageResource file = default, MessageResource thumbnail = default, HeightEnum height = default)
        {
            File = file ?? throw new ArgumentNullException(nameof(file));
            Height = height;
            Thumbnail = thumbnail;
        }

        /// <summary>
        /// Gets or Sets File
        /// </summary>
        [JsonProperty("file")]
        public MessageResource File { get; set; }

        /// <summary>
        /// Gets or Sets Thumbnail
        /// </summary>
        [JsonProperty("thumbnail")]
        public MessageResource Thumbnail { get; set; }
        
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