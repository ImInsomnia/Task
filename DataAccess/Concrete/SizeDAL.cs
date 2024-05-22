using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class SizeDAL : RepositoryBase<Size, AppDbContext>, ISizeDAL
    {
    }
}
