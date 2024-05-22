using Core.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color model);
        IResult Delete(Color model);
        IResult Update(Color model);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
    }
}
