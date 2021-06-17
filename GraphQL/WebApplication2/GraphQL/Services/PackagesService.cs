using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Sundio.Packages.Models;
using Sundio.Common;
using Sundio.Web.HttpClient.NetCore;
using Sundio.Web.JsonApi.Models;

namespace WebApplication2.GraphQL.Services
{
    public class PackagesService
    {
        public PackagesService()
        {
        }

        public async Task<IEnumerable<PackageModel>> GetPackages()
        {
            var relativePath = "/EZ/packages/search?page[limit]=100";
            var apiUri = new Uri("https://acpt-packages.api.sundiogroup.com");
            IApiCaller apiCaller =
                new ApiCaller(apiUri)
                    .WithSundioAcceptHeader()
                    .WithHttpMethod(HttpMethod.Get)
                    .WithRelativePath(relativePath);

            var result = await apiCaller
                .ExecuteAsync<SearchResponseModel>();

            return result.Results;
        }
    }
}