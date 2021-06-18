using System.Linq;
using HotChocolate.Types;
using Sundio.Packages.Models;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.GraphQL.Packages
{
    public class PackagesType : ObjectType<PackageModelExtended>
    {

        protected override void Configure(IObjectTypeDescriptor<PackageModelExtended> descriptor)
        {
            descriptor.Description("Used to define todo item for a specific list");

            descriptor.Field(x => x.Accommodation)
                .ResolveWith<Resolvers>(p => p.GetName(default!))
                .Description("This is Accommodation Name");

            descriptor.Field(x => x.AccommodationId)
                .Description("Accommodation identifier");
        }

        private class Resolvers
        {
            public Accommodation GetName(PackageModelExtended item)
            {
                var service = new ProductsService();
                var product = service.GetProduct(item.AccommodationId.ToString()).Result;
                var acco = new Accommodation
                {
                    Name = product?.Name,
                    AccoImageUrl = product?.Images?.FirstOrDefault()
                };
                return acco;
            }
        }
    }
}
