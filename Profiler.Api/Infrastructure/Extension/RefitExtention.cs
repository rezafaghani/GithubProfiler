using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace Profiler.Api.Infrastructure.Extension
{
    public static class RefitExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostUrl"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T For<T>(string hostUrl) => RestService.For<T>(hostUrl, GetNewtonsoftJsonRefitSettings());
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T For<T>(HttpClient client) => RestService.For<T>(client, GetNewtonsoftJsonRefitSettings());

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RefitSettings GetNewtonsoftJsonRefitSettings() => new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));

    }
}