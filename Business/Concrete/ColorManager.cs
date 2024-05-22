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
    public class ColorManager : IColorService
    {
        private readonly IColorDAL _colorDAL;
        public ColorManager()
        {
            _colorDAL = new ColorDAL();
        }
        public IResult Add(Color model)
        {
            #region Validate Model

            var validation = new ColorValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _colorDAL.Add(model);
            return new SuccessResult(CommonMessages.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult Delete(Color model)
        {
            var deletedEntity = _colorDAL.Get(x => x.ID == model.ID);
            if (deletedEntity != null)
            {
                deletedEntity.Deleted = model.ID;
                _colorDAL.Update(deletedEntity);
                return new SuccessResult(CommonMessages.DATA_DELETED_SUCCESSFULLY);
            }
            return new ErrorResult(CommonMessages.DATA_NOT_FOUND_FOR_DELETE);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll(x=>x.Deleted == 0));
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Color model)
        {
            #region Validate Model

            var validation = new ColorValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _colorDAL.Update(model);
            return new SuccessResult(CommonMessages.DATA_UPDATED_SUCCESSFULLY);
        }
    }
}
