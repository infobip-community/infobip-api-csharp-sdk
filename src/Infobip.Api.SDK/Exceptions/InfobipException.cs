using System;
using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    /// <summary>
    /// Represents errors that occur during api endpoints call execution
    /// </summary>
    public class InfobipException : Exception
    {
        /// <summary>
        /// Gets <c>StatusCode</c>, a coded numerical value that represents result of the http response call. It maps directly to standard values from <see cref="HttpStatusCode"/>.
        /// </summary>
        /// <returns>The <c>StatusCode</c> value.</returns>
        public int StatusCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfobipException"></see> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InfobipException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfobipException"></see> class with a specified error message and <c>StatusCode</c>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">The status code that represents result of the http response call.</param>
        public InfobipException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}