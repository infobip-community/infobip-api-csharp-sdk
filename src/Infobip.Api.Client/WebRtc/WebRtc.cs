using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Infobip.Api.Client.WebRtc.Models;
using RestSharp;

namespace Infobip.Api.Client.WebRtc
{
    internal class WebRtc : IWebRtc
    {
        private readonly IRestClient _client;

        public WebRtc(IRestClient client)
        {
            _client = client;
        }

        public async Task<WebRtcTokenResponse> GenerateWebRtcToken(WebRtcTokenRequest requestPayload)
        {
            var request = new RestRequest("webrtc/1/token", Method.POST);

            var result = await _client.ExecuteAsync<WebRtcTokenResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<List<WebRtcApplicationResponse>> GetWebRtcApplications()
        {
            var request = new RestRequest("webrtc/1/applications", Method.GET);

            var result = await _client.ExecuteAsync<List<WebRtcApplicationResponse>>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WebRtcApplicationResponse> SaveWebRtcApplication(WebRtcApplicationRequest requestPayload)
        {
            var request = new RestRequest("webrtc/1/applications", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WebRtcApplicationResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WebRtcApplicationResponse> GetWebRtcApplication(string id)
        {
            var request = new RestRequest("webrtc/1/applications/{id}", Method.GET);
            request.AddOrUpdateParameter("id", id);

            var result = await _client.ExecuteAsync<WebRtcApplicationResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WebRtcApplicationResponse> UpdateWebRtcApplication(string id, WebRtcApplicationRequest requestPayload)
        {
            var request = new RestRequest("webrtc/1/applications/{id}", Method.PUT);
            request.AddOrUpdateParameter("id", id);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WebRtcApplicationResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task DeleteWebRtcApplication(string id)
        {
            var request = new RestRequest("webrtc/1/applications/{id}", Method.DELETE);
            request.AddOrUpdateParameter("id", id);

            var result = await _client.ExecuteAsync(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }
        }
    }
}