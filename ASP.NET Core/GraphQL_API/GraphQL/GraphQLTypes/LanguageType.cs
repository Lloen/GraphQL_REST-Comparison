using GraphQL.Types;
using GraphQL_API.Models;

namespace GraphQL_API.GraphQL.Types
{
    internal class LanguageType : ObjectGraphType<Language>
    {
        public LanguageType()
        {
            Name = "Language";

            Field(x => x.LanguageId, type: typeof(IdGraphType)).Description("The ID of the language.");
            Field(x => x.Language1).Description("The language");
        }
    }
}