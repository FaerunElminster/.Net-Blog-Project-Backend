using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Repositories.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool LoginUser(LoginRequest loginRequest)
        {
            string email = loginRequest.Email;

            bool response = _userRepository.Queryable().Any(user => user.UserEmail == loginRequest.Email && user.UserPassword == loginRequest.Password);

            return response;
        }

        public RegisterResponse RegisterUser(RegisterRequest registerRequest) 
        {
            //var mappedEntity = _mapper.Map<User>(registerRequest);
            User user = new User();
            user.UserName = registerRequest.Name;
            user.UserEmail = registerRequest.Email;
            user.UserPassword = registerRequest.Password;
            user.CreatedDate = DateTime.Now;
            _userRepository.Add(user);
            RegisterResponse registerResponse = new RegisterResponse();
            registerResponse.CreatedDate = DateTime.Now;
            registerResponse.Name = registerRequest.Name;
            return registerResponse;
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.UserEmail == email);
        }
    }
}
