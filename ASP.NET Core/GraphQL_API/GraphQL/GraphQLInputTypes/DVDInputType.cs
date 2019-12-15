using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.GraphQL.GraphQLInputTypes
{
    public class DVDInputType : InputObjectGraphType
    {
        public DVDInputType()
        {
            Name = "DvdInput";

            Field<IdGraphType>("dvdID");
            Field<IntGraphType>("movieId");
            Field<StringGraphType>("isbn");
            Field<StringGraphType>("edition");
            Field<StringGraphType>("region");

        }
    }
}
