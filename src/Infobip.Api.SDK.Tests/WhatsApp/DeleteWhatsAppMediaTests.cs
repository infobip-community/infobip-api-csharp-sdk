using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WhatsApp.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class DeleteWhatsAppMediaTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public DeleteWhatsAppMediaTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task DeleteWhatsAppMedia_Call_ExpectsSuccess()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act/Assert
            var response = await apiClient.WhatsApp.DeleteWhatsAppMedia("sender", request);
        }

        [Fact]
        public async Task DeleteWhatsAppMedia_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.DeleteWhatsAppMedia(null, request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task DeleteWhatsAppMedia_UrlInvalid_Call_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequestUrlInvalid();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.DeleteWhatsAppMedia("sender", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task DeleteWhatsAppMedia_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responseMessage = GetBadRequestResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.DeleteWhatsAppMedia("sender", request);

            // Assert
            await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task DeleteWhatsAppMedia_Call_With_ForbiddenResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responseMessage = GetForbiddenResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.DeleteWhatsAppMedia("sender", request);

            // Assert
            await Assert.ThrowsAsync<InfobipForbiddenException>(act);
        }


        private DeleteWhatsAppMediaRequest GetRequest()
        {
            var request = new DeleteWhatsAppMediaRequest("http://example.com/media");
            return request;
        }

        private DeleteWhatsAppMediaRequest GetRequestUrlInvalid()
        {
            var request = new DeleteWhatsAppMediaRequest("");
            return request;
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = new StringContent("OK")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("*/*")
                    }
                }
            };
        }

        private static HttpResponseMessage GetForbiddenResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Forbidden,
                Content = new StringContent("FORBIDDEN")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("*/*")
                    }
                }
            };
        }

        private static HttpResponseMessage GetBadRequestResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("BAD_REQUEST")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("*/*")
                    }
                }
            };
        }
    }
}