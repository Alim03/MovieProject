using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.ViewModels.Movie
{
    public class MovieViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ReleasedDate { get; set; }
        public string CreatedDate { get; set; }
        public int Time { get; set; }
        public string Image { get; set; }
    }
}
