using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipUnauthorizedException : InfobipException
    {
        public InfobipUnauthorizedException(string message) : base(message, (int)HttpStatusCode.Unauthorized)
        {
        }
    }
}
