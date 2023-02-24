using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieProject.Domain.ViewModels.Movie
{
    public class AddMovieViewModel
    {
        public string Title { get; set; }
        public DateTime ReleasedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int? Time { get; set; }
        public IFormFile Image { get; set; }
        public string? Cover { get; set; }
        public string? Summary { get; set; }


        [Display(Name = "Artists")]
        public int[] SelectedArtistsIds { get; set; }
        public IEnumerable<SelectListItem>? Artists { get; set; }

        [Display(Name = "Genre")]
        public int[] SelectedGenreIds { get; set; }
        public IEnumerable<SelectListItem>? Genre { get; set; }

        [Display(Name = "Languages")]
        public int[] SelectedLanguagesIds { get; set; }
        public IEnumerable<SelectListItem>? Languages { get; set; }

        [Display(Name = "Country")]
        public int[] SelectedCountryIds { get; set; }
        public IEnumerable<SelectListItem>? Country { get; set; }


    }
}
