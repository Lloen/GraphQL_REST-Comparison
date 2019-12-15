using GraphQL.Types;
using GraphQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.GraphQL.Types
{
    public class DVDLangaugeType : ObjectGraphType<Dvdlanguage>
    {
        public DVDLangaugeType()
        {
            Name = "DVD Language and Audio Format map";

            Field<DVDType>(nameof(Dvd));
            Field<LanguageType>(nameof(Language));
            Field<AudioFormatType>(nameof(AudioFormat));

        }
    }
}
