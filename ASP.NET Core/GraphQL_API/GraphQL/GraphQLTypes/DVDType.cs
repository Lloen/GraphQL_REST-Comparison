using GraphQL.Types;
using GraphQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.GraphQL.Types
{
    public class DVDType : ObjectGraphType<Dvd>
    {
        public DVDType()
        {
            Name = "DVD";

            Field(x => x.DvdId, type: typeof(IdGraphType)).Description("The ID of the DVD.");
            Field<MovieType>(nameof(Movie));
            Field(x => x.MovieId).Description("MovieID");
            Field(x => x.Isbn).Description("DVD ISBN number");
            Field(x => x.Edition).Description("The edition of the DVD");
            Field(x => x.Region).Description("The region of the DVD");
        }
    }
}
