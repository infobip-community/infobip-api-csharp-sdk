namespace Infobip.Api.Client.Exceptions
{
    public class InfobipTooManyRequestsException : InfobipException
    {
        public InfobipTooManyRequestsException(string message) : base(message)
        {
        }
    }
}
