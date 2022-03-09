using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.Validation.DataAnnotations;

namespace Infobip.Api.SDK.Validation
{
    /// <summary>
    ///  Provides request payload validation functionality.
    /// </summary>
    public interface IRequestValidator
    {
        /// <summary>
        /// Validates request payload using <see cref="IDataAnnotationsValidator"/>.
        /// If request is not valid <see cref="InfobipRequestNotValidException"/> with specified message and validation results is thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestPayload">Request payload object.</param>
        /// <param name="message">Message to use as exception message if request is not valid.</param>
        void Validate<T>(T requestPayload, string message = "Request is invalid.");
    }
}