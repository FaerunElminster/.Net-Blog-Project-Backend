using Business.Dtos.Requests;
using Business.Dtos.Responses;
using NttBlog.Controllers;

namespace Business.Abstracts
{
    public interface IBlogService
    {
        DeleteBlogResponse DeleteBlog(DeleteBlogRequest deleteBlogRequest);
        PublishBlogResponse PublishBlog(PublishBlogRequest publishBlogRequest);
        UpdateBlogResponse UpdateBlog(UpdateBlogRequest updateBlogRequest);

    }
}
