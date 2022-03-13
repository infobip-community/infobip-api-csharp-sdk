﻿using System.Net;

namespace Infobip.Api.SDK.Exceptions
{
    public class InfobipUnauthorizedException : InfobipException
    {
        public string MessageId { get; }
        public string Text { get; }

        public InfobipUnauthorizedException(string message, string messageId, string text) : base(message, (int)HttpStatusCode.Unauthorized)
        {
            MessageId = messageId;
            Text = text;
        }
    }
}
