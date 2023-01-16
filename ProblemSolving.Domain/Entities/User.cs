using ProblemSolving.Domain.Primitives;
using ProblemSolving.Domain.ValueObjects;

namespace ProblemSolving.Domain.Entities
{
    public sealed class User : Entity
    {
        public UserName UserName { get; set; }
        public PassWord PassWord { get; set; }
        public FullName FullName { get; set; }
        public DateTime JoinDate { get; set; }
        public IList<Star> Stars { get; set; }
        public User(Guid id, string userName, string passWord, string fullName, DateTime joinDate) : base(id)
        {
            UserName = UserName.Create(userName);
            PassWord = PassWord.Create(passWord);
            FullName = FullName.Create(fullName);
            JoinDate = joinDate;
        }

        public User(Guid id):base(id)
        {
        }
    }
}
