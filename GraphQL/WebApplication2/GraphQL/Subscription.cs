using HotChocolate;
using HotChocolate.Types;
using WebApplication2.Models;

namespace WebApplication2.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public ItemList OnListAdded([EventMessage] ItemList list) => list;
    }
}