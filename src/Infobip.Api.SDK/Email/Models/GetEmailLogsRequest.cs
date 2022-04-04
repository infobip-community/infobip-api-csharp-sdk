using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetEmailLogsRequest
    /// </summary>
    public class GetEmailLogsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailLogsRequest" /> class.
        /// </summary>
        public GetEmailLogsRequest()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailLogsRequest" /> class.
        /// </summary>
        /// <param name="messageId">MessageId data that will be included in Delivery Report..</param>
        /// <param name="from">From email address.</param>
        /// <param name="to">The recipient email address.</param>
        /// <param name="bulkId">Bulk ID that uniquely identifies the request.</param>
        /// <param name="generalStatus">Indicates whether the initiated email has been successfully sent, not sent, delivered, not delivered, waiting for delivery or any other possible status.</param>
        /// <param name="sentSince">Tells when the email was initiated. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.</param>
        /// <param name="sentUntil">Tells when the email request was processed by Infobip.Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.</param>
        /// <param name="limit">Maximum number of logs.</param>
        public GetEmailLogsRequest(string messageId = default, string from = default, string to = default,
            string bulkId = default, string generalStatus = default,
            DateTime? sentSince = default, DateTime? sentUntil = default,
            int limit = default)
        {
            MessageId = messageId;
            From = from;
            To= to;
            BulkId = bulkId;
            GeneralStatus = generalStatus;
            SentSince = sentSince;
            SentUntil = sentUntil;
            Limit = limit;
        }

        /// <summary>
        /// The ID that uniquely identifies the sent email.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; }

        /// <summary>
        /// From email address.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; }

        /// <summary>
        /// The recipient email address.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; }

        /// <summary>
        /// Bulk ID that uniquely identifies the request.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; }

        /// <summary>
        /// Indicates whether the initiated email has been successfully sent, not sent, delivered, not delivered, waiting for delivery or any other possible status.
        /// </summary>
        [JsonProperty("generalStatus")]
        public string GeneralStatus { get; }

        /// <summary>
        /// Tells when the email was initiated. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sentSince")]
        public DateTime? SentSince { get; }

        /// <summary>
        /// Tells when the email request was processed by Infobip.Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sentUntil")]
        public DateTime? SentUntil { get; }

        /// <summary>
        /// Maximum number of logs.
        /// </summary>
        [JsonProperty("limit")]
        [Range(0, int.MaxValue)]
        public int? Limit { get; }
    }
}
