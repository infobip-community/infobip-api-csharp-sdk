using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// SendMmsMessageRequest
    /// </summary>
    public class SendMmsMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMmsMessageRequest" /> class.
        /// </summary>
        public SendMmsMessageRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMmsMessageRequest" /> class.
        /// </summary>
        /// <param name="head">Head part contains required information for sending MMS to an end user.</param>
        /// <param name="text">Body of message.</param>
        /// <param name="media"></param>
        /// <param name="externallyHostedMedia">Optional part containing information for externally hosted media (image, video).</param>
        /// <param name="smil">Optional part containing information for externally hosted media (image, video).</param>
        public SendMmsMessageRequest(MmsMessageHead head, string text = default, Stream media = default, List<ExternallyHostedMedia> externallyHostedMedia = default, string smil = default)
        {
            Head = head ?? throw new ArgumentNullException(nameof(head));
            Text = text;
            Media = media;
            ExternallyHostedMedia = externallyHostedMedia;
            Smil = smil;
        }

        /// <summary>
        /// Head part contains required information for sending MMS to an end user.
        /// </summary>
        //[JsonProperty("head")]
        [Required]
        public MmsMessageHead Head { get; set; }

        /// <summary>
        /// Optional part sent with content type as text/plain containing textual message data. Can be sent with different charsets.
        /// </summary>
        //[JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Optional part sent with content type for media containing media(image, video) message data.
        /// </summary>
        //[JsonProperty("media")]
        public Stream Media { get; set; }

        /// <summary>
        /// Optional part containing information for externally hosted media (image, video).
        /// </summary>
        //[JsonProperty("externallyHostedMedia")]
        public List<ExternallyHostedMedia> ExternallyHostedMedia { get; set; }

        /// <summary>
        /// Optional part sent with content type application/smil containing SMIL - synchronized multimedia integration language file. Used for parts ordering in MMS.
        /// </summary>
        //[JsonProperty("smil")]
        public string Smil { get; set; }
    }
}
