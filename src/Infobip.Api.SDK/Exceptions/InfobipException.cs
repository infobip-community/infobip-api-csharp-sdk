using System;
using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipException : Exception
    {
        public int StatusCode { get; }

        public InfobipException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        public InfobipException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}