using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Sundio.Products.Models.Accommodations;
using Sundio.Products.Models.Impl;
using Sundio.Web.HttpClient.NetCore;

namespace WebApplication2.Services
{
    public class ProductsService
    {
        public static IEnumerable<AccommodationModel> _accommodations;

        public async Task<AccommodationModel> GetProduct(string id)
        {
            if (_accommodations == null)
            {

                var relativePath = $"/EZ/products2/accommodations";
                var apiUri = new Uri("https://acpt-products.api.sundiogroup.com");
                IApiCaller apiCaller =
                    new ApiCaller(apiUri)
                        .WithSundioAcceptHeader()
                        .WithHttpMethod(HttpMethod.Get)
                        .WithRelativePath(relativePath);

                System.Diagnostics.Debug.WriteLine($"{apiUri}{relativePath}");

                var result = await apiCaller
                    .ExecuteAsync<IEnumerable<AccommodationModel>>();

                _accommodations = result;
            }

            return _accommodations?.FirstOrDefault(x => x.Id.ToString() == id);
        }
    }
}