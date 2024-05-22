using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CityDAL : RepositoryBase<City, AppDbContext>, ICityDAL
    {
    }
}
