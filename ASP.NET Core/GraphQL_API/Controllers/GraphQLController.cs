using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL_API.GraphQL.GraphQLSchema;
using GraphQL_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_API.Controllers
{
    [Route("graphql/dvds")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly DVD_LibraryContext _db;

        public GraphQLController(DVD_LibraryContext db) => _db = db;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new DVDQuery(_db)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
