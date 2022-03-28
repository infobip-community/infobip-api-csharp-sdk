using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// MmsDeliveryReport
    /// </summary>
    public class MmsDeliveryReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MmsDeliveryReport" /> class.
        /// </summary>
        [JsonConstructor]
        public MmsDeliveryReport() { }

        /// <summary>
        /// Bulk ID.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Message ID.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Destination address.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Sender ID that can be alphanumeric or numeric.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Tells when the MMS was sent. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sentAt")]
        public DateTimeOffset SentAt { get; set; }

        /// <summary>
        /// Tells when the SMS was finished processing by Infobip (i.e., delivered to the destination, delivered to the destination network, etc.). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("doneAt")]
        public DateTimeOffset DoneAt { get; set; }

        /// <summary>
        /// The number of parts the sent MMS was split into.
        /// </summary>
        [JsonProperty("mmsCount")]
        public int MmsCount { get; set; }

        /// <summary>
        /// Mobile country and network codes.
        /// </summary>
        [JsonProperty("mccMnc")]
        public string MccMnc { get; set; }

        /// <summary>
        /// Callback data sent through callbackData field in fully featured MMS message.
        /// </summary>
        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Sent SMS price.
        /// </summary>
        [JsonProperty("price")]
        public MmsPrice Price { get; set; }

        /// <summary>
        /// Indicates the status of the message and how to recover from an error should there be any.
        /// </summary>
        [JsonProperty("status")]
        public MmsStatus Status { get; set; }

        /// <summary>
        /// Indicates whether an error occurred during the query execution.
        /// </summary>
        [JsonProperty("error")]
        public MmsError Error { get; set; }
    }
}