using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProblemSolving.Domain.Entities;
using ProblemSolving.Domain.Interfaces;
using ProblemSolving.Domain.ValueObjects;

namespace ProblemSolving.Application.Controllers.PostController
{
    [Route("/api/[Controller]")]
    [ApiController]
    
    public class PostController : ControllerBase
    {

        public readonly IPostRepository _postRepo;

        public PostController(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            return await _postRepo.GetPost(id);
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepo.GetPosts();
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(AddPostReq post)
        {
            var newPost = new Post(new Guid(), Title.Create(post.title), ProblemSolving.Domain.ValueObjects.Content.Create(post.content), new Guid(),DateTime.UtcNow, DateTime.UtcNow);
            return await _postRepo.AddPost(newPost);
        }

        [HttpPut]
        public async Task<IActionResult> Updatepost(UpdatePostReq post)
        {
            var postUpdate = await _postRepo.GetPost(post.PostId);
            if(postUpdate == null)
            {
                return NotFound();
            }
            else
            {
                postUpdate.Content = ProblemSolving.Domain.ValueObjects.Content.Create(post.Content);
                postUpdate.Title = Title.Create(post.Title);
                await _postRepo.UpdatePost(postUpdate);
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(Guid PostId)
        {
            var postUpdate = await _postRepo.GetPost(PostId);
            if (postUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await _postRepo.DeletePost(PostId);
                return Ok();
            }
        }
    }
}
