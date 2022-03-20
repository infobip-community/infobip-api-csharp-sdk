using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// Email log
    /// </summary>
    public class EmailLogReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailLogReport" /> class.
        /// </summary>
        /// <param name="messageId">The ID that uniquely identifies the sent email request..</param>
        /// <param name="to">The recipient email address..</param>
        /// <param name="from">From email address..</param>
        /// <param name="text">The text from email body..</param>
        /// <param name="sentAt">Tells when the email was initiated. Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;..</param>
        /// <param name="doneAt">Tells when the email request was processed by Infobip.</param>
        /// <param name="messageCount">Email request count..</param>
        /// <param name="price">price.</param>
        /// <param name="status">status.</param>
        /// <param name="bulkId">The ID that uniquely identifies the request..</param>
        public EmailLogReport(string messageId = default, string to = default, string from = default, string text = default, DateTime sentAt = default, DateTime doneAt = default, int messageCount = default, EmailMessagePrice price = default, EmailMessageStatus status = default, string bulkId = default)
        {
            MessageId = messageId;
            To = to;
            From = from;
            Text = text;
            SentAt = sentAt;
            DoneAt = doneAt;
            MessageCount = messageCount;
            Price = price;
            Status = status;
            BulkId = bulkId;
        }

        /// <summary>
        /// The ID that uniquely identifies the sent email request.
        /// </summary>
        /// <value>The ID that uniquely identifies the sent email request.</value>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// The recipient email address.
        /// </summary>
        /// <value>The recipient email address.</value>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// From email address.
        /// </summary>
        /// <value>From email address.</value>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// The text from email body.
        /// </summary>
        /// <value>The text from email body.</value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Tells when the email was initiated. Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.
        /// </summary>
        /// <value>Tells when the email was initiated. Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.</value>
        [JsonProperty("sentAt")]
        public DateTime SentAt { get; set; }

        /// <summary>
        /// Tells when the email request was processed by Infobip
        /// </summary>
        /// <value>Tells when the email request was processed by Infobip</value>
        [JsonProperty("doneAt")]
        public DateTime DoneAt { get; set; }

        /// <summary>
        /// Email request count.
        /// </summary>
        /// <value>Email request count.</value>
        [JsonProperty("messageCount")]
        public int MessageCount { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [JsonProperty("price")]
        public EmailMessagePrice Price { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty("status")]
        public EmailMessageStatus Status { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the request.
        /// </summary>
        /// <value>The ID that uniquely identifies the request.</value>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }
    }
}