using Core.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISizeService
    {
        IResult Add(Size model);
        IResult Delete(Size model);
        IResult Update(Size model);
        IDataResult<List<Size>> GetAll();
        IDataResult<Size> GetById(int id);
    }
}
