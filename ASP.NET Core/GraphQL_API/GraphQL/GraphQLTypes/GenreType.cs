using GraphQL.Types;
using GraphQL_API.Models;

namespace GraphQL_API.GraphQL.Types
{
    internal class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Name = "Genre";

            Field(x => x.GenreId, type: typeof(IdGraphType)).Description("The ID of the genre.");
            Field(x => x.Genre1).Description("The genre");
        }
    }
}