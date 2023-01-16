using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Domain.Entities
{
    public sealed class Star
    {

        public Guid Post_Id { get; set; }
        public Post Post { get; set; }  
        public Guid User_Id { get; set; }
        public User User { get; set; }

        public Star(Guid post_Id, Post post, Guid user_Id, User user)
        {
            Post_Id = post_Id;
            Post = post;
            User_Id = user_Id;
            User = user;
        }

        public Star()
        {
        }
    }
}
