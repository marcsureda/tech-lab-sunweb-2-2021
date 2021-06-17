using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Types;

namespace WebApplication1.Controllers
{
    public class GraphQLDemoSchema : Schema, ISchema
    {
        public GraphQLDemoSchema(IServiceProvider
            provider) : base(provider)
        {
            Query = provider.GetRequiredService<AuthorQuery>();
        }
    }
}