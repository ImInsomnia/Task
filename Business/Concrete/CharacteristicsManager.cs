using Business.Abstract;
using Business.Extensions;
using Business.Validations;
using Core.Constants;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CharacteristicsManager : ICharacteristicsService
    {
        private readonly ICharacteristicsDAL _characteristicsDAL;
        public CharacteristicsManager()
        {
            _characteristicsDAL = new CharacteristicsDAL();
        }
        public IResult Add(Characteristics model)
        {
            #region Validate Model

            var validation = new CharacteristicsValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _characteristicsDAL.Add(model);
            return new SuccessResult(CommonMessages.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult Delete(Characteristics model)
        {
            var deletedEntity = _characteristicsDAL.Get(x => x.ID == model.ID);
            if (deletedEntity != null)
            {
                deletedEntity.Deleted = model.ID;
                _characteristicsDAL.Update(deletedEntity);
                return new SuccessResult(CommonMessages.DATA_DELETED_SUCCESSFULLY);
            }
            return new ErrorResult(CommonMessages.DATA_NOT_FOUND_FOR_DELETE);
        }

        public IDataResult<List<Characteristics>> GetAll()
        {
            return new SuccessDataResult<List<Characteristics>>(_characteristicsDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Characteristics> GetById(int id)
        {
            return new SuccessDataResult<Characteristics>(_characteristicsDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Characteristics model)
        {
            #region Validate Model

            var validation = new CharacteristicsValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _characteristicsDAL.Update(model);
            return new SuccessResult(CommonMessages.DATA_UPDATED_SUCCESSFULLY);
        }
    }
}
