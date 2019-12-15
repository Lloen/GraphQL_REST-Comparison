using GraphQL;
using GraphQL.Types;
using GraphQL_API.GraphQL.GraphQLInputTypes;
using GraphQL_API.GraphQL.Types;
using GraphQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.GraphQL.GraphQLSchema
{
    public class DVDMutation : ObjectGraphType
    {
        public DVDMutation(DVD_LibraryContext db)
        {
            Field<DVDType>(
              "createDvd",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<DVDInputType>> { Name = "dvd", Description = "The Data of the DVD." }
              ),
              resolve: context =>
              {
                  var dvd = context.GetArgument<Dvd>("dvd");

                  dvd.DvdId = null;

                  db.Dvd.Add(dvd);
                  db.SaveChanges();

                  return dvd;
              });

            Field<DVDType>(
                "updateDvd",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DVDInputType>> { Name = "dvd", Description = "The Data of the DVD." },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the DVD." }
                ),
                resolve: context =>
                {
                    var dvd = context.GetArgument<Dvd>("dvd");
                    long dvdID = context.GetArgument<int>("id");

                    var dvdDB = db.Dvd.Find(dvdID);
                    if (dvdDB == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find DVD in db."));
                        return null;
                    }

                    dvdDB.Edition = dvd.Edition;
                    dvdDB.Isbn = dvd.Isbn;
                    dvdDB.MovieId = dvd.MovieId;
                    dvdDB.Region = dvd.Region;

                    db.SaveChanges();

                    return dvdDB;
                });

            Field<StringGraphType>(
                "deleteDvd",
                arguments: new QueryArguments(
                    new QueryArgument< NonNullGraphType < IdGraphType >> { Name = "id", Description = "The ID of the DVD." }
                ),
                resolve: context =>
                {
                    long id = context.GetArgument<int>("id");
                    var dvdDB = db.Dvd.Find(id);

                    if (dvdDB == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find DVD in db."));
                        return null;
                    }

                    db.Dvd.Remove(dvdDB);
                    db.SaveChanges();

                    return $"The dvd with the id: {id} has been successfully deleted.";
                });
        }
    }
}
