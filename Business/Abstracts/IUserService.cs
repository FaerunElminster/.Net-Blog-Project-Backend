using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities;

namespace Business.Abstracts
{
    public interface IUserService
    {
        public RegisterResponse RegisterUser(RegisterRequest registerRequest);
        public bool LoginUser(LoginRequest loginRequest);
        User GetByMail(string email);
    }
}
