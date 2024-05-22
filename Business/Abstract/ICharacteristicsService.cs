using Core.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICharacteristicsService
    {
        IResult Add(Characteristics model);
        IResult Delete(Characteristics model);
        IResult Update(Characteristics model);
        IDataResult<List<Characteristics>> GetAll();
        IDataResult<Characteristics> GetById(int id);
    }
}
