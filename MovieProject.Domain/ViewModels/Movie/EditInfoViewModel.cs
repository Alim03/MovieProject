using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Domain.ViewModels.Movie
{
    public class EditInfoViewModel
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string title { get; set; }
    }
}
