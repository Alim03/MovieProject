using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieProject.Domain.ViewModels.Artist
{
    public class EditArtistViewModel
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public DateTime? BirthDate { get; set; }

        [MaxLength(1024)]
        public string? Bio { get; set; }

        [Display(Name = "Career")]
        public int[] SelectedCareerIds { get; set; }

        public List<SelectListItem>? Careers { get; set; }
    }
}