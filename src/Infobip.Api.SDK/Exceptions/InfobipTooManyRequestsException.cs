using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipTooManyRequestsException : InfobipException
    {
        public InfobipTooManyRequestsException(string message) : base(message, 429)
        {
        }
    }
}
