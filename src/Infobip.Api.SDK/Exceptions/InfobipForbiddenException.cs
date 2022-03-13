using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipForbiddenException : InfobipException
    {
        public string MessageId { get; }
        public string Text { get; }

        public InfobipForbiddenException(string message, string messageId, string text) : base(message, (int)HttpStatusCode.Forbidden)
        {
            MessageId = messageId;
            Text = text;
        }
    }
}
