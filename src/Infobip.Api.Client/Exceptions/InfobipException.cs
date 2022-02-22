using System;

namespace Infobip.Api.Client.Exceptions
{
    public class InfobipException : Exception
    {
        public InfobipException(string message) : base(message)
        {
        }
    }
}