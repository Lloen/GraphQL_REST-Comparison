using GraphQL.Types;
using GraphQL_API.Models;

namespace GraphQL_API.GraphQL.Types
{
    internal class MovieType : ObjectGraphType<Movie>
    {
        public MovieType()
        {
            Name = "Movie";

            Field(x => x.MovieId, type: typeof(IdGraphType)).Description("The ID of the movie.");
            Field(x => x.MovieTitle).Description("The title of the movie");
            Field(x => x.Length).Description("The length of the movie in minutes");
            Field<GenreType>(nameof(Genre));
            Field(x => x.ReleaseDate).Description("The release date");
        }
    }
}