using GraphQL.Types;
using GraphQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.GraphQL.Types
{
    public class AudioFormatType : ObjectGraphType<AudioFormat>
    {
        public AudioFormatType()
        {
            Name = "Audio Format";

            Field(x => x.AudioId, type: typeof(IdGraphType)).Description("The ID of the audio format.");
            Field(x => x.Format).Description("The audio format.");
        }
    }
}
