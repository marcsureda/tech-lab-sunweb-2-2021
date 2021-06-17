using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using WebApplication2.Data;
using WebApplication2.GraphQL.Lists;
using WebApplication2.GraphQL.Items;
using WebApplication2.Models;

namespace WebApplication2.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] ApiDbContext context, [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var list = new ItemList
            {
                Name = input.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync(cancellationToken);

            // we emit our subscription
            await eventSender.SendAsync(nameof(Subscription.OnListAdded), list, cancellationToken);

            return new AddListPayload(list);
        }


        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] ApiDbContext context)
        {
            var item = new ItemData
            {
                Description = input.description,
                IsDone = input.done,
                Title = input.title,
                ListId = input.listId
            };

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return new AddItemPayload(item);
        }


    }
}