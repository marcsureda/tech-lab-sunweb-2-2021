using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Sundio.Products.Models.Accommodations;
using Sundio.Products.Models.Impl;
using Sundio.Web.HttpClient.NetCore;

namespace WebApplication2.Services
{
    public class ProductsService
    {
        public async Task<AccommodationModel> GetProduct(string id)
        {
            var relativePath = $"/EZ/products2/accommodations/{id}";
            var apiUri = new Uri("https://acpt-products.api.sundiogroup.com");
            IApiCaller apiCaller =
                new ApiCaller(apiUri)
                    .WithSundioAcceptHeader()
                    .WithHttpMethod(HttpMethod.Get)
                    .WithRelativePath(relativePath);

            System.Diagnostics.Debug.WriteLine($"{apiUri}{relativePath}");

            var result = await apiCaller
                .ExecuteAsync<AccommodationModel>();

            return result;
        }
    }
}