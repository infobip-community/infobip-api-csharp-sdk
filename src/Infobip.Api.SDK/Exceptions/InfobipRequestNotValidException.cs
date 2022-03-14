using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    /// <summary>
    /// Represents errors that occur during validation of the model that represents request.<see cref="HttpStatusCode.BadRequest"/>
    /// </summary>
    public class InfobipRequestNotValidException : InfobipException
    {
        /// <summary>
        /// Gets a collection with validation results.
        /// </summary>
        /// <returns>A collection with validation results.</returns>
        public IEnumerable<ValidationResult> ValidationResults { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfobipRequestNotValidException"></see> class with a specified error message, message id and text.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="validationResults">The collection of validation results.</param>
        public InfobipRequestNotValidException(string message, IEnumerable<ValidationResult> validationResults) : base(message, (int)HttpStatusCode.BadRequest)
        {
            ValidationResults = validationResults;
        }
    }
}
