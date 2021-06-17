using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Sundio.Packages.Models;
using Sundio.Web.HttpClient.NetCore;

namespace WebApplication2.Services
{
    public class PackagesService
    {
        public async Task<IEnumerable<PackageModel>> GetPackages()
        {
            var relativePath = "/EZ/packages/search?page[limit]=100";
            var apiUri = new Uri("https://acpt-packages.api.sundiogroup.com");
            IApiCaller apiCaller =
                new ApiCaller(apiUri)
                    .WithSundioAcceptHeader()
                    .WithHttpMethod(HttpMethod.Get)
                    .WithRelativePath(relativePath);

            System.Diagnostics.Debug.WriteLine($"{apiUri}{relativePath}");

            var result = await apiCaller
                .ExecuteAsync<ProductSearchResponseModel>();

            return result.Results;
        }
    }
}