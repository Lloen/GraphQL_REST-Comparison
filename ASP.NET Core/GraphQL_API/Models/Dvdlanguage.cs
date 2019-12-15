using System;
using System.Collections.Generic;

namespace GraphQL_API.Models
{
    public partial class Dvdlanguage
    {
        public long DvdId { get; set; }
        public long LanguageId { get; set; }
        public long AudioFormatId { get; set; }
        public long DvdLanguageId { get; set; }

        public virtual AudioFormat AudioFormat { get; set; }
        public virtual Dvd Dvd { get; set; }
        public virtual Language Language { get; set; }
    }
}
