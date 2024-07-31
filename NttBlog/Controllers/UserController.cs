using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NttBlog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IBlogService blogService,IConfiguration configuration)
        {
            _userService = userService;
            _blogService = blogService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public RegisterResponse Register(RegisterRequest registerRequest) => _userService.RegisterUser(registerRequest);

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginrequest)
        {
            bool response = _userService.LoginUser(loginrequest);
            if (response)
            {
                var token = TokenHandler.CreateToken(_configuration);
                return Ok(token);
            }
            return BadRequest();
        }

        [HttpPost("Publish")]
        public PublishBlogResponse PublishBlog(PublishBlogRequest publishBlogRequest) => _blogService.PublishBlog(publishBlogRequest);

        [HttpPost("Delete")]
        public DeleteBlogResponse DeleteBlog(DeleteBlogRequest deleteBlogRequest) => _blogService.DeleteBlog(deleteBlogRequest);

        [HttpPost("Update")]
        public UpdateBlogResponse UpdateBlog(UpdateBlogRequest updateBlogRequest) => _blogService.UpdateBlog(updateBlogRequest);

        [HttpGet("Test")]
        public ActionResult<string> GetTest()
        {
            return Ok("Hello World");
        }
    }
}
