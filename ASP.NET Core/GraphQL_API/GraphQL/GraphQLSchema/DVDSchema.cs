using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.GraphQL.GraphQLSchema
{
    public class DVDSchema : Schema
    {
        public DVDSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<DVDQuery>();
            Mutation = resolver.Resolve<DVDMutation>();
        }
    }
}
