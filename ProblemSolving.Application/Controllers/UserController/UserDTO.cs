using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Application.Controllers.UserController
{
    public class UpdateUserReq
    {
        public Guid UserId { get; set; }
        public string Password { get; set; } = null!;
        public string Fullname { get; set; } = null!;

    }

    public class AddUserReq
    {

        public string UserName { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public string FullName { get; set; } = null!;

    }
}
