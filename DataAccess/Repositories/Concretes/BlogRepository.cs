using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Entities;

namespace DataAccess.Repositories.Concretes
{
    public class BlogRepository : Repository<Blog, BaseDbContext>, IBlogRepository
    {

    }
}
