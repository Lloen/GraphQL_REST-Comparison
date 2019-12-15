using GraphQL.Types;
using GraphQL_API.GraphQL.Types;
using GraphQL_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_API.GraphQL.GraphQLSchema
{
    public class DVDQuery : ObjectGraphType
    {
        public DVDQuery(DVD_LibraryContext db)
        {
            FieldAsync<DVDType>(
              "getDvd",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the DVD." }),
              resolve: async context =>
              {
                      var id = context.GetArgument<int>("id");
                      var dvd = await db.Dvd.Select(d => new Dvd
                      {
                          DvdId = d.DvdId,
                          Isbn = d.Isbn,
                          MovieId = d.MovieId,
                          Edition = d.Edition,
                          Region = d.Region,
                          Movie = db.Movie.Select(m => new Movie
                          {
                              MovieId = m.MovieId,
                              MovieTitle = m.MovieTitle,
                              Length = m.Length,
                              GenreId = m.GenreId,
                              ReleaseDate = m.ReleaseDate,
                              Genre = db.Genre.Select(g => new Genre
                              {
                                  GenreId = g.GenreId,
                                  Genre1 = g.Genre1
                              })
                              .Where(g => g.GenreId == m.GenreId)
                              .FirstOrDefault()
                          })
                                   .Where(m => m.MovieId == d.MovieId)
                                   .FirstOrDefault()
                      })
            .Where(d => d.DvdId == id)
            .FirstOrDefaultAsync();
                  return dvd;
              });

            FieldAsync<ListGraphType<DVDType>>(
              "getDvds",
              resolve: async context =>
              {
                  var dvds = await db.Dvd.Select(d => new Dvd
                  {
                      DvdId = d.DvdId,
                      Isbn = d.Isbn,
                      MovieId = d.MovieId,
                      Edition = d.Edition,
                      Region = d.Region,
                      Movie = db.Movie.Select(m => new Movie
                      {
                          MovieId = m.MovieId,
                          MovieTitle = m.MovieTitle,
                          Length = m.Length,
                          GenreId = m.GenreId,
                          ReleaseDate = m.ReleaseDate,
                          Genre = db.Genre.Select(g => new Genre
                          {
                              GenreId = g.GenreId,
                              Genre1 = g.Genre1
                          })
                          .Where(g => g.GenreId == m.GenreId)
                          .FirstOrDefault()
                      })
                            .Where(m => m.MovieId == d.MovieId)
                            .FirstOrDefault()
                  })
                .ToListAsync();


                  return dvds;

              });

        }
    }
}
