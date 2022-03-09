using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipRequestNotValidException : InfobipException
    {
        public IEnumerable<ValidationResult> ValidationResults { get; }


        public InfobipRequestNotValidException(string message, IEnumerable<ValidationResult> validationResults) : base(message, (int)HttpStatusCode.BadRequest)
        {
            ValidationResults = validationResults;
        }
    }
}
