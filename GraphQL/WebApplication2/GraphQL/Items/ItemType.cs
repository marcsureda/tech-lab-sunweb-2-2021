using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.GraphQL.Items
{
    public class ItemType: ObjectType<ItemData>
    {
        // since we are inheriting from objtype we need to override the functionality
        protected override void Configure(IObjectTypeDescriptor<ItemData> descriptor)
        {
            descriptor.Description("Used to define todo item for a specific list");

            descriptor.Field(x => x.ItemList)
                .ResolveWith<Resolvers>(p => p.GetList(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("This is the list that the item belongs to");

            descriptor.Field(x => x.IsDone)
                .Description("If the user has completed this item");
        }

        private class Resolvers
        {
            public ItemList GetList(ItemData item, [ScopedService] ApiDbContext context)
            {
                return context.Lists.FirstOrDefault(x => x.Id == item.ListId);
            }
        }

    }
}