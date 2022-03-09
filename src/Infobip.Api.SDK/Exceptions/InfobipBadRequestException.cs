using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipBadRequestException : InfobipException
    {
        public InfobipBadRequestException(string message) : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
