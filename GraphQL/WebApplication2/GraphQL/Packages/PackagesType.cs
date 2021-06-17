using HotChocolate.Types;
using Sundio.Packages.Models;

namespace WebApplication2.GraphQL.Packages
{
    public class PackagesType : ObjectType<PackageModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PackageModel> descriptor)
        {
            descriptor.Description("Used to define todo item for a specific list");

            //descriptor.Field(x => x.ItemList)
            //    .ResolveWith<Resolvers>(p => p.GetList(default!, default!))
            //    .UseDbContext<ApiDbContext>()
            //    .Description("This is the list that the item belongs to");

            descriptor.Field(x => x.AccommodationId)
                .Description("Accommodation identifier");
        }
    }
}
