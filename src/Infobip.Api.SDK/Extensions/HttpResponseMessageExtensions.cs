using System.Net.Http;
using System.Threading.Tasks;
using Infobip.Api.SDK.Exceptions;

namespace Infobip.Api.SDK.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        public static async Task ThrowIfRequestWasUnsuccessful(this HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                await Task.CompletedTask;
            }
            else
            {
                var content = await message.Content.ReadAsStringAsync();
                var contentMessage = string.IsNullOrWhiteSpace(content) ? string.Empty : $"Content: {content}";
                throw new InfobipException(
                    $"Response status code does not indicate success: {message.StatusCode} ({message.ReasonPhrase}).{contentMessage}");
            }
        }
    }
}
