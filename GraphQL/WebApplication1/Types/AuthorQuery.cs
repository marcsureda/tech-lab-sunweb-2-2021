using GraphQL;
using GraphQL.Types;

namespace WebApplication1.Types
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(AuthorService authorService)
        {
            int id = 0;
            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context => authorService.GetAllAuthors());
            Field<AuthorType>(
                name: "author",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    id = context.GetArgument<int>("id");
                    return authorService.GetAuthorById(id);
                }
            );
            Field<ListGraphType<BlogPostType>>(
                name: "blogs",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => authorService.GetPostsByAuthor(id));
        }
    }
}