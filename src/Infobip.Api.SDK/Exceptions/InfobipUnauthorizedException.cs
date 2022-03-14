using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    /// <summary>
    /// Represents errors that occur during api endpoints call execution in case when http response status code is <see cref="HttpStatusCode.Unauthorized"/>
    /// </summary>
    public class InfobipUnauthorizedException : InfobipException
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
        /// Initializes a new instance of the <see cref="InfobipUnauthorizedException"></see> class with a specified error message, message id and text.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="messageId">The MessageId that describes the error.</param>
        /// <param name="text">The text that describes the error in more details.</param>
        public InfobipUnauthorizedException(string message, string messageId, string text) : base(message, (int)HttpStatusCode.Unauthorized)
        {
            MessageId = messageId;
            Text = text;
        }
    }
}
