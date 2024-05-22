using Core.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IResult Add(Country model);
        IResult Delete(Country model);
        IResult Update(Country model);
        IDataResult<List<Country>> GetAll();
        IDataResult<Country> GetById(int id);
    }
}
