using System.Collections.Generic;
using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipBadRequestException : InfobipException
    {
        public string MessageId { get; }
        public string Text { get; }
        public IDictionary<string, string[]> ValidationErrors { get; }

        public InfobipBadRequestException(string message, string messageId, string text, IDictionary<string, string[]> validationErrors) : base(message, (int)HttpStatusCode.BadRequest)
        {
            MessageId = messageId;
            Text = text;
            ValidationErrors = validationErrors;
        }
    }
}
