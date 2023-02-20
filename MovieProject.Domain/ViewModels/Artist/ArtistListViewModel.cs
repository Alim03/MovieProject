using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Domain.ViewModels.Artist
{
    public class ArtistListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }
    }
}
