using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class SendBinarySmsMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendBinarySmsMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendBinarySmsMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendBinarySmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<SendSmsMessageResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.SendBinarySmsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendBinarySmsMessage_MessagesInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendBinarySmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessagesInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendBinarySmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendBinarySmsMessage_MessageFromInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendBinarySmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageFromInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendBinarySmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendBinarySmsMessage_MessageHexInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendBinarySmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageHexInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendBinarySmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendBinarySmsMessage_MessageDestinationsInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendBinarySmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageDestinationsInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendBinarySmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendBinarySmsMessage_MessageNotifyContentTypeInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendBinarySmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageNotifyContentTypeInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendBinarySmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendBinarySmsMessage_MessageDestinationToInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendBinarySmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageDestinationToInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendBinarySmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static SendSmsBinaryMessageRequest GetRequest()
        {
            var messages = new List<SmsBinaryMessage>
            {
                new SmsBinaryMessage
                {
                    From = "CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    },
                    Binary = new SmsBinaryContent(hex:"48 65 6c 6c 6f 21")
                }
            };

            var request = new SendSmsBinaryMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsBinaryMessageRequest GetRequestMessagesInvalid()
        {
            var request = new SendSmsBinaryMessageRequest("2034072219640523072", new List<SmsBinaryMessage>());
            return request;
        }

        private static SendSmsBinaryMessageRequest GetRequestMessageFromInvalid()
        {
            var messages = new List<SmsBinaryMessage>
            {
                new SmsBinaryMessage
                {
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    },
                    Binary = new SmsBinaryContent(hex:"48 65 6c 6c 6f 21")
                }
            };

            var request = new SendSmsBinaryMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsBinaryMessageRequest GetRequestMessageHexInvalid()
        {
            var messages = new List<SmsBinaryMessage>
            {
                new SmsBinaryMessage
                {
                    From = "CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    },
                    Binary = new SmsBinaryContent(hex:"invalid")
                }
            };

            var request = new SendSmsBinaryMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsBinaryMessageRequest GetRequestMessageDestinationsInvalid()
        {
            var messages = new List<SmsBinaryMessage>
            {
                new SmsBinaryMessage
                {
                    From = "CompanyName",
                    Binary = new SmsBinaryContent(hex:"48 65 6c 6c 6f 21")
                }
            };

            var request = new SendSmsBinaryMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsBinaryMessageRequest GetRequestMessageNotifyContentTypeInvalid()
        {
            var messages = new List<SmsBinaryMessage>
            {
                new SmsBinaryMessage
                {
                    From = "CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    },
                    Binary = new SmsBinaryContent(hex:"48 65 6c 6c 6f 21"),
                    NotifyContentType = "something"
                }
            };

            var request = new SendSmsBinaryMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsBinaryMessageRequest GetRequestMessageDestinationToInvalid()
        {
            var destinationToInvalid = new string('a', 51);
            var messages = new List<SmsBinaryMessage>
            {
                new SmsBinaryMessage
                {
                    From = "CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", destinationToInvalid)
                    },
                    Binary = new SmsBinaryContent(hex:"48 65 6c 6c 6f 21")
                }
            };

            var request = new SendSmsBinaryMessageRequest("2034072219640523072", messages);
            return request;
        }
    }
}
