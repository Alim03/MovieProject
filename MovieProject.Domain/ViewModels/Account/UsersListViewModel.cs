using MovieProject.Domain.Entities.Movie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.ViewModels.Account
{
    public class UsersListViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }


        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
        public string CreatedDate { get; set; }

    }
}
