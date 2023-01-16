using ProblemSolving.Domain.Entities;

namespace ProblemSolving.Domain.Interfaces
{
    public interface IPostRepository
    {
        public Task<List<Post>> GetPosts();
        public Task<Post> GetPost(Guid PostId);
        public Task<Post> AddPost(Post post);
        public Task UpdatePost(Post post);
        public Task DeletePost(Guid PostId);
    }

}
