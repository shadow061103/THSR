using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace THSR.Repository.Infrastructure.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private readonly IRestClient _restClient;
        private readonly IConfiguration _configuration;

        public ApiHelper(IRestClient restClient, IConfiguration configuration)
        {
            _restClient = restClient;
            _configuration = configuration;
        }

        /// <summary>
        /// 非同步呼叫Api(無參數)
        /// </summary>
        /// <param name="uri">Api位置</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string uri)
        {
            var request = new RestRequest(uri);
            request.Method = Method.GET;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            var response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("連線失敗", response.ErrorException);
            }

            if (response.ErrorException != null)
            {
                throw new Exception("Error retrieving response", response.ErrorException);
            }

            return JsonSerializer.Deserialize<T>(response.Content);
        }

        /// <summary>
        /// 非同步呼叫PTX Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public async Task<T> GetPTXAsync<T>(string uri)
        {
            var APPID = this._configuration.GetValue<string>("AppId");
            var APPKey = this._configuration.GetValue<string>("AppKey");
            string xdate = DateTime.Now.ToUniversalTime().ToString("r");
            string Signature = HMACHelper.Signature($"x-date: {xdate}", APPKey);
            var sAuth = $"hmac username=\"{APPID}\", algorithm=\"hmac-sha1\", headers=\"x-date\",signature=\"{Signature}\"";

            var request = new RestRequest(uri);
            request.Method = Method.GET;
            request.AddHeader("Content-Encoding", "gzip");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", sAuth);
            request.AddHeader("x-date", xdate);
            var response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("連線失敗", response.ErrorException);
            }

            if (response.ErrorException != null)
            {
                throw new Exception("Error retrieving response", response.ErrorException);
            }

            return JsonSerializer.Deserialize<T>(response.Content);
        }

        /// <summary>
        /// 非同步呼叫Api(帶參數)
        /// </summary>
        /// <param name="uri">Api位置</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T, P>(string uri, P param)
        {
            var request = new RestRequest(uri);
            request.Method = Method.POST;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(param);
            var response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = JsonSerializer.Deserialize<T>(response.Content);
                if (error is null)
                {
                    throw new Exception("連線失敗", response.ErrorException);
                }
                //throw new InvalidOperationException(error, response.ErrorException);
            }

            if (response.ErrorException != null)
            {
                throw new Exception("Error retrieving response", response.ErrorException);
            }

            return JsonSerializer.Deserialize<T>(response.Content);
        }

        /// <summary>
        /// 非同步呼叫Api(無參數)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URL.</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(string uri)
        {
            var request = new RestRequest(uri);
            request.Method = Method.POST;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            var response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("連線失敗", response.ErrorException);
            }

            if (response.ErrorException != null)
            {
                throw new Exception("Error retrieving response", response.ErrorException);
            }

            return JsonSerializer.Deserialize<T>(response.Content);
        }
    }
}