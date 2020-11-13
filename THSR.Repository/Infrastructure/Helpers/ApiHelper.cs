using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

namespace THSR.Repository.Infrastructure.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private readonly IRestClient _restClient;

        public ApiHelper(IRestClient restClient)
        {
            _restClient = restClient;
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