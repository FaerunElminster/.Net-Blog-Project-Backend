
namespace Business.Dtos.Requests
{
    public class PublishBlogRequest
    {
        public Guid UserId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

    }
}
