using Microsoft.EntityFrameworkCore;
using ProblemSolving.Data.Context;
using ProblemSolving.Domain.Entities;
using ProblemSolving.Domain.Interfaces;

namespace ProblemSolving.Domain.Repositories
{
    public sealed class PostRepository : IPostRepository
    {

        public readonly ProblemSolvingContext _psContext;

        public PostRepository(ProblemSolvingContext psContext)
        {
            _psContext = psContext;
        }

        public async Task<Post> AddPost(Post post)
        {
            _psContext.Posts.Add(post);
            await _psContext.SaveChangesAsync();
            return post;
        }

        public async Task DeletePost(Guid PostId)
        {
            var post = await GetPost(PostId);
            _psContext.Posts.Remove(post);
            await _psContext.SaveChangesAsync();
        }

        public  async Task<Post> GetPost(Guid PostId)
        {
            return await _psContext.Posts.FindAsync(PostId);
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _psContext.Posts.ToListAsync();
        }

        public Task UpdatePost(Post post)
        {
            _psContext.Posts.Entry(post).State = EntityState.Modified;
            return _psContext.SaveChangesAsync();
        }

        public async Task<bool> CheckExist(Guid PostId)
        {

            if(await _psContext.Posts.FindAsync(PostId) != null)
            {
                return true;
            }
            return false;
        }
    }
}
