using System;
using System.Collections.Generic;

namespace GraphQL_API.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Dvd = new HashSet<Dvd>();
        }

        public long MovieId { get; set; }
        public string MovieTitle { get; set; }
        public long Length { get; set; }
        public long GenreId { get; set; }
        public string ReleaseDate { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Dvd> Dvd { get; set; }
    }
}
