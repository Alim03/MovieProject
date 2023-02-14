using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Application.Security.PasswordHelper
{
    public interface IPasswordHasher
    {
        string EncodePasswordMd5(string pass);
    }
}
