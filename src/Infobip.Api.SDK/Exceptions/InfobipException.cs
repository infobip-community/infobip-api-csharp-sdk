using System;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipException : Exception
    {
        public InfobipException(string message) : base(message)
        {
        }
    }
}