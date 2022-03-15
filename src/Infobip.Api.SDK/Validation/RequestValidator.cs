using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.Validation.DataAnnotations;

namespace Infobip.Api.SDK.Validation
{
    /// <inheritdoc />
    public sealed class RequestValidator : IRequestValidator
    {
        private readonly IDataAnnotationsValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestValidator"/> class.
        /// </summary>
        /// <param name="validator">An instance of the <see cref="IDataAnnotationsValidator"/>.</param>
        public RequestValidator(IDataAnnotationsValidator validator)
        {
            _validator = validator;
        }

        /// <inheritdoc />
        public void Validate<T>(T requestPayload, string message = "Request is invalid.")
        {
            var validationResults = new List<ValidationResult>();

            var valid = _validator.TryValidateObjectRecursive(requestPayload, validationResults);

            if (!valid)
            {
                throw new InfobipRequestNotValidException(message, validationResults);
            }
        }
    }
}
