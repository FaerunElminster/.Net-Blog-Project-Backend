using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Repositories.Abstracts;
using Entities;
using NttBlog.Controllers;

namespace Business.Concretes
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUserRepository _userRepository;

        public BlogService(IBlogRepository blogRepository) : base()
        {
            _blogRepository = blogRepository;
        }

        public DeleteBlogResponse DeleteBlog(DeleteBlogRequest deleteBlogRequest)
        {
            _blogRepository.Delete(deleteBlogRequest.Blog);
            DeleteBlogResponse deleteBlogResponse = new DeleteBlogResponse();
            deleteBlogResponse.DeletedTime = DateTime.Now;
            return deleteBlogResponse;
        }

        public PublishBlogResponse PublishBlog(PublishBlogRequest publishBlogRequest)
        { 
            Blog blog = new Blog();
            blog.UserId = publishBlogRequest.UserId;
            blog.Header = publishBlogRequest.Header;
            blog.Body = publishBlogRequest.Body;
            blog.CreatedDate = DateTime.Now;
            _blogRepository.Add(blog);
            PublishBlogResponse publishBlogResponse = new PublishBlogResponse();
            publishBlogResponse.PublishedDate = DateTime.Now;
            return publishBlogResponse;
        }

        public UpdateBlogResponse UpdateBlog(UpdateBlogRequest updateBlogRequest)
        {
            Blog blog = _blogRepository.Get(x => x.Id == updateBlogRequest.BlogId);
            blog.Header = updateBlogRequest.NewHeader;
            blog.Body = updateBlogRequest.NewBody;
            UpdateBlogResponse updateBlogResponse = new UpdateBlogResponse();
            updateBlogResponse.UpdatedDate = DateTime.Now;
            return updateBlogResponse;
        }

        /*
        public Blog FindById(Guid id)
        {
            try
            {
                var selectedBlog = _blogRepository.GetAll(x => x.Id == id).FirstOrDefault();
                return selectedBlog != null ? selectedBlog : throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw;
            }

        }
        */
    }
}
