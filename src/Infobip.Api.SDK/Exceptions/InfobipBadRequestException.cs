using System.Collections.Generic;
using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    /// <summary>
    /// Represents errors that occur during api endpoints call execution in case when http response status code is <see cref="HttpStatusCode.BadRequest"/>
    /// </summary>
    public class InfobipBadRequestException : InfobipException
    {
        /// <summary>
        /// Gets error message id.
        /// </summary>
        /// <returns>The <c>MessageId</c> value.</returns>
        public string MessageId { get; }

        /// <summary>
        /// Gets error text.
        /// </summary>
        /// <returns>The <c>Text</c> value.</returns>
        public string Text { get; }

        /// <summary>
        /// Gets generic collection of validation errors.
        /// </summary>
        /// <returns>Generic collection with validation errors.</returns>
        public IDictionary<string, string[]> ValidationErrors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfobipBadRequestException"></see> class with a specified error message, message id, text and list of validation errors.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="messageId">The MessageId that describes the error.</param>
        /// <param name="text">The text that describes the error in more details.</param>
        /// <param name="validationErrors">The list of validation errors.</param>
        public InfobipBadRequestException(string message, string messageId, string text, IDictionary<string, string[]> validationErrors) : base(message, (int)HttpStatusCode.BadRequest)
        {
            MessageId = messageId;
            Text = text;
            ValidationErrors = validationErrors;
        }
    }
}
