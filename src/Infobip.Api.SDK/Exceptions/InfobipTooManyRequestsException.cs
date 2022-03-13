using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipTooManyRequestsException : InfobipException
    {
        public string MessageId { get; }
        public string Text { get; }

        public InfobipTooManyRequestsException(string message, string messageId, string text) : base(message, 429)
        {
            MessageId = messageId;
            Text = text;
        }
    }
}
