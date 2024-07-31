using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Entities;

namespace DataAccess.Repositories.Concretes
{
    public class UserRepository : Repository<User, BaseDbContext>, IUserRepository
    {
        public UserRepository()
        {
        }
    }
}
