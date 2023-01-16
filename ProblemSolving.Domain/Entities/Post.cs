using ProblemSolving.Domain.Primitives;
using ProblemSolving.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace ProblemSolving.Domain.Entities
{
    public sealed class Post : Entity
    {

        public Title Title { get; set; }
        public Content Content { get; set; }
        public Guid Owner { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set;}
        public IList<Star> Stars { get; set; }

        public Post(Guid id):base(id)
        {
        }

        [JsonConstructor]
        public Post(Guid id, Title title, Content content, Guid owner, DateTime createAt, DateTime update_at) : base(id)
        {
            Title = title;
            Content = content;
            Owner = owner;
            Create_at = createAt;
            Update_at = update_at;
        }

       

    }
}
