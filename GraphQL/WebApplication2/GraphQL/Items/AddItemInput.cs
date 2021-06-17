namespace WebApplication2.GraphQL.Items
{
    public record AddItemInput(string title, string description, bool done, int listId);
}