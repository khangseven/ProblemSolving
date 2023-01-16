namespace ProblemSolving.Application.Controllers.PostController
{
    public class AddPostReq
    {
        public string title { get; set; } = null!;
        public string content { get; set; } = null!;
    }

    public class UpdatePostReq
    {

        public Guid PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;


    }
}
