using System;
using System.Collections.Generic;

namespace GraphQL_API.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movie = new HashSet<Movie>();
        }

        public long GenreId { get; set; }
        public string Genre1 { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
