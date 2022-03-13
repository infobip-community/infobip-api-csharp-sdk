using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipNotFoundException : InfobipException
    {
        public string MessageId { get; }
        public string Text { get; }

        public InfobipNotFoundException(string message, string messageId, string text) : base(message, (int)HttpStatusCode.NotFound)
        {
            MessageId = messageId;
            Text = text;
        }
    }
}
