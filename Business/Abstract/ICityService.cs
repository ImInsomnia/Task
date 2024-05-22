using Core.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICityService
    {
        IResult Add(City model);
        IResult Delete(City model);
        IResult Update(City model);
        IDataResult<List<City>> GetAll();
        IDataResult<City> GetById(int id);
    }
}
