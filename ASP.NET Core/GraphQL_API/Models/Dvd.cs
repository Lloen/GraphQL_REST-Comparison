using System;
using System.Collections.Generic;

namespace GraphQL_API.Models
{
    public partial class Dvd
    {
        public Dvd()
        {
            Dvdlanguage = new HashSet<Dvdlanguage>();
        }

        public long? DvdId { get; set; }
        public long MovieId { get; set; }
        public string Isbn { get; set; }
        public string Edition { get; set; }
        public string Region { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ICollection<Dvdlanguage> Dvdlanguage { get; set; }
    }
}
