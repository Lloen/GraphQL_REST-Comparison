using System;
using System.Collections.Generic;

namespace GraphQL_API.Models
{
    public partial class AudioFormat
    {
        public AudioFormat()
        {
            Dvdlanguage = new HashSet<Dvdlanguage>();
        }

        public long AudioId { get; set; }
        public string Format { get; set; }

        public virtual ICollection<Dvdlanguage> Dvdlanguage { get; set; }
    }
}
