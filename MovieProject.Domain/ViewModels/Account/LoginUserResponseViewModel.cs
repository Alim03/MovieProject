using MovieProject.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.ViewModels.Account
{
    public class LoginUserResponseViewModel
    {
        public LoginUserViewModel? LoginUserViewModel { get; set; }
        public ResponseViewModel? ResponseViewModel { get; set; }
        public UserProfileViewModel? userProfileViewModel { get; set; }
    }
}
