using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.Exceptions.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infobip.Api.SDK.Extensions
{
    /// <summary>
    ///  Extension methods for <see cref="HttpResponseMessage"/>.
    /// </summary>
    internal static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Throws an exception in case when <see cref="HttpResponseMessage"/> status code is not <c>SuccessStatusCode</c>
        /// </summary>
        /// <param name="responseMessage">An <see cref="HttpResponseMessage"/></param>
        /// <returns></returns>
        /// <exception cref="InfobipBadRequestException"></exception>
        /// <exception cref="InfobipUnauthorizedException"></exception>
        /// <exception cref="InfobipForbiddenException"></exception>
        /// <exception cref="InfobipNotFoundException"></exception>
        /// <exception cref="InfobipTooManyRequestsException"></exception>
        /// <exception cref="InfobipException"></exception>
        public static async Task ThrowIfRequestWasUnsuccessful(this HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                await Task.CompletedTask;
            }
            else
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var statusCode = responseMessage.StatusCode;
                var reasonPhrase = responseMessage.ReasonPhrase;

                var exceptionMessage = GetDefaultExceptionMessage(responseContent, statusCode, reasonPhrase);
                var exceptionMessageId = string.Empty;
                string exceptionText;
                IDictionary<string, string[]> exceptionValidationErrors = new Dictionary<string, string[]>();

                // Api is not returning "application/json" content type always, so we need to check it before we try to deserialize exception response.
                var contentType = responseMessage.Content.Headers.ContentType?.MediaType;
                if (contentType == "application/json")
                {
                    // Special case handling 
                    // For WhatsApp "Mark As Read" endpoint, for 400 response json is returned, but It's formatted different then all other json exceptions
                    // In this case returned data is:
                    // {
                    //     "error": "string"
                    // }
                    // Otherwise, default response is looking like this:
                    // {
                    //     "requestError": {
                    //         "serviceException": {
                    //             "messageId": "TOO_MANY_REQUESTS",
                    //             "text": "Too many requests"
                    //         }
                    //     }
                    // }
                    // 
                    // We'll use JToken to check response format...

                    var errorResponseJObject = JObject.Parse(responseContent);
                    var errorToken = errorResponseJObject.SelectToken("error");
                    if (errorToken != null)
                    {
                        exceptionMessageId = exceptionText = errorToken.Value<string>();
                    }
                    else
                    {
                        var exceptionResponse = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);
                        exceptionMessageId = exceptionResponse.RequestError.ServiceException.MessageId;
                        exceptionText = exceptionResponse.RequestError.ServiceException.Text;
                        exceptionValidationErrors = exceptionResponse.RequestError.ServiceException.ValidationErrors;
                    }
                }
                else // "*/*" 
                {
                    exceptionText = responseContent;

                    // Set exceptionMessageId according to status code.
                    // By documentation we have: 
                    // - 403 Sender not found
                    // - 404 Media not found
                    if (statusCode == HttpStatusCode.Forbidden)
                    {
                        exceptionMessageId = "Sender not found";
                    } else if (statusCode == HttpStatusCode.NotFound)
                    {
                        exceptionMessageId = "Media not found";
                    }
                }

                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new InfobipBadRequestException(exceptionMessage,
                            exceptionMessageId,
                            exceptionText,
                            exceptionValidationErrors);
                    case HttpStatusCode.Unauthorized:
                        throw new InfobipUnauthorizedException(exceptionMessage,
                            exceptionMessageId,
                            exceptionText);
                    case HttpStatusCode.Forbidden:
                        throw new InfobipForbiddenException(exceptionMessage,
                            exceptionMessageId,
                            exceptionText);
                    case HttpStatusCode.NotFound:
                        throw new InfobipNotFoundException(exceptionMessage,
                            exceptionMessageId,
                            exceptionText);
                    case (HttpStatusCode)429: // Too Many Requests
                        throw new InfobipTooManyRequestsException(exceptionMessage,
                            exceptionMessageId,
                            exceptionText);
                    default:
                        throw new InfobipException(exceptionMessage, (int)statusCode);
                }
            }
        }

        private static string GetDefaultExceptionMessage(string responseContent, HttpStatusCode statusCode, string reasonPhrase)
        {
            var contentMessage = string.IsNullOrWhiteSpace(responseContent) ? string.Empty : $"Content: {responseContent}";
            return $"Response status code does not indicate success: {statusCode} ({reasonPhrase}).{contentMessage}";
        }
    }
}
