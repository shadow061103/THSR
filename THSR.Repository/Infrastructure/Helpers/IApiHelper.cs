using System.Threading.Tasks;

namespace THSR.Repository.Infrastructure.Helpers
{
    public interface IApiHelper
    {
        /// <summary>
        /// 非同步呼叫Api(無參數)
        /// </summary>
        /// <param name="uri">Api位置</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string uri);

        /// <summary>
        /// 非同步呼叫PTX Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        Task<T> GetPTXAsync<T>(string uri);

        /// <summary>
        /// 非同步呼叫Api(帶參數)
        /// </summary>
        /// <param name="uri">Api位置</param>
        /// <returns></returns>
        Task<T> PostAsync<T, P>(string uri, P param);

        /// <summary>
        /// 非同步呼叫Api(無參數)
        /// </summary>
        /// <param name="uri">Api位置</param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string uri);
    }
}