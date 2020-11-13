using System;
using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace THSR.Api.Infrastructure.Extension
{
    public static class ElasticsearchExtensions
    {
        /// <summary>
        /// Adds the elasticsearch.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new ElasticSearchSetting();
            configuration.GetSection("elasticsearch").Bind(settings);
            var defaultIndex = settings.Index;

            var nodeUris = settings.Nodes.Select(x => new Uri(x));

            var connectionPool = new StaticConnectionPool(nodeUris);

            var connectionSetting = new ConnectionSettings(connectionPool)
                .DefaultIndex(defaultIndex)
                .DisableAutomaticProxyDetection()
                .DisableDirectStreaming();

            var client = new ElasticClient(connectionSetting);

            var response = client.Indices.Exists(defaultIndex);

            //if (response.Exists.Equals(false))
            //{
            //    var a = client.Indices.Create(defaultIndex, c => c.Map<Traininfo>(m => m
            //            .AutoMap()
            //            .Properties(p => p
            //                .Keyword(kw => kw
            //                    .Name(w => w.Train)
            //                ))
            //        )
            //    );
            //    Console.WriteLine(a.IsValid);
            //}

            services.AddSingleton<IElasticClient>(client);
        }
    }

    /// <summary>
    /// ElasticSearch Setting
    /// </summary>
    public class ElasticSearchSetting
    {
        public string Index { get; set; }

        public IList<string> Nodes { get; set; }
    }
}