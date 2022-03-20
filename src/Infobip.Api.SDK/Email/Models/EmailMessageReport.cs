using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// Send email message report
    /// </summary>
    public class EmailMessageReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessageReport" /> class.
        /// </summary>
        /// <param name="bulkId">The ID that uniquely identifies bulks of request.</param>
        /// <param name="messageId">The ID that uniquely identifies the sent email request.</param>
        /// <param name="to">The recipient email address.</param>
        /// <param name="sentAt">Tells when the email was initiated. Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.</param>
        /// <param name="doneAt">Tells when the email request was processed by Infobip.</param>
        /// <param name="messageCount">Email request count.</param>
        /// <param name="price">price.</param>
        /// <param name="status">status.</param>
        /// <param name="error">error.</param>
        public EmailMessageReport(string bulkId = default, string messageId = default, string to = default, DateTime sentAt = default, DateTime doneAt = default, int messageCount = default, EmailMessagePrice price = default, EmailMessageStatus status = default, EmailMessageReportError error = default)
        {
            BulkId = bulkId;
            MessageId = messageId;
            To = to;
            SentAt = sentAt;
            DoneAt = doneAt;
            MessageCount = messageCount;
            Price = price;
            Status = status;
            Error = error;
        }

        /// <summary>
        /// The ID that uniquely identifies bulks of request.
        /// </summary>
        /// <value>The ID that uniquely identifies bulks of request.</value>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

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
        /// Gets or Sets Error
        /// </summary>
        [JsonProperty("error")]
        public EmailMessageReportError Error { get; set; }
    }
}