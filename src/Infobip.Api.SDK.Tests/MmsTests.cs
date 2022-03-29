using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.MMS.Models;
using Infobip.Api.SDK.Shared.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests
{
    public class MmsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public MmsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendSingleMmsMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/SendSingleMmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<SendMmsMessageResponse>(responsePayloadFileName);

            var deliveryTimeWindow = new DeliveryTimeWindow(new List<DeliveryDay> { DeliveryDay.Monday });
            var head = new MmsMessageHead("InfoMMS", "41793026727", deliveryTimeWindow);
            var request = new SendMmsMessageRequest
            {
                Head = head
            };

            // Act
            var response = await apiClient.Mms.SendSingleMmsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetOutboundMmsMessageDeliveryReports_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/GetOutboundMmsMessageDeliveryReportsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetMmsDeliveryReportResponse>(responsePayloadFileName);

            var request = new GetMmsDeliveryReportRequest();

            // Act
            var response = await apiClient.Mms.GetOutboundMmsMessageDeliveryReports(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetInboundMmsMessages_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/GetInboundMmsMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetInboundMmsMessagesResponse>(responsePayloadFileName);

            var request = new GetInboundMmsMessagesRequest();

            // Act
            var response = await apiClient.Mms.GetInboundMmsMessages(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        // Throws InfobipBadRequestException
        [Fact]
        public async Task SendSingleMmsMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/SendSingleMmsMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var deliveryTimeWindow = new DeliveryTimeWindow(new List<DeliveryDay> { DeliveryDay.Monday });
            var head = new MmsMessageHead("InfoMMS", "41793026727", deliveryTimeWindow);
            var request = new SendMmsMessageRequest
            {
                Head = head
            };

            // Act
            Func<Task> act = () => apiClient.Mms.SendSingleMmsMessage(request);
        
            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        // Throws InfobipException
        [Fact]
        public async Task SendSingleMmsMessage_Call_With_InternalServerErrorResponse_Throws_InfobipException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/SendSingleMmsMessageInternalServerError.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.InternalServerError));

            var deliveryTimeWindow = new DeliveryTimeWindow(new List<DeliveryDay> { DeliveryDay.Monday });
            var head = new MmsMessageHead("InfoMMS", "41793026727", deliveryTimeWindow);
            var request = new SendMmsMessageRequest
            {
                Head = head
            };

            // Act
            Func<Task> act = () => apiClient.Mms.SendSingleMmsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipException>(act);
        }

        [Fact]
        public async Task SendSingleMmsMessage_HeadInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/SendSingleMmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new SendMmsMessageRequest();

            // Act
            Func<Task> act = () => apiClient.Mms.SendSingleMmsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSingleMmsMessage_DeliveryTimeWindowInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/SendSingleMmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var head = new MmsMessageHead("InfoMMS", "41793026727", new DeliveryTimeWindow(new List<DeliveryDay>()));
            var request = new SendMmsMessageRequest
            {
                Head = head
            };
            request.Head.DeliveryTimeWindow = null;

            // Act
            Func<Task> act = () => apiClient.Mms.SendSingleMmsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}
