using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.ViewModels.Account
{
    public class EditUserViewModel
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }

    }
}
