using System;
using System.Collections.Generic;

namespace GraphQL_API.Models
{
    public partial class Language
    {
        public Language()
        {
            Dvdlanguage = new HashSet<Dvdlanguage>();
        }

        public long LanguageId { get; set; }
        public string Language1 { get; set; }

        public virtual ICollection<Dvdlanguage> Dvdlanguage { get; set; }
    }
}
