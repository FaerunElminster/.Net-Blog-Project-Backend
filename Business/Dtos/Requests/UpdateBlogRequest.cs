
namespace Business.Dtos.Requests
{
    public class UpdateBlogRequest
    {
        public Guid BlogId { get; set; }
        public string NewHeader { get; set; }
        public string NewBody { get; set; }
    }
}
