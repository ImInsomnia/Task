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
    public class SizeManager : ISizeService
    {
        private readonly ISizeDAL _sizeDAL;
        public SizeManager()
        {
            _sizeDAL = new SizeDAL();
        }
        public IResult Add(Size model)
        {
            #region Validate Model

            var validation = new SizeValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _sizeDAL.Add(model);
            return new SuccessResult(CommonMessages.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult Delete(Size model)
        {
            var deletedEntity = _sizeDAL.Get(x => x.ID == model.ID);
            if (deletedEntity != null)
            {
                deletedEntity.Deleted = model.ID;
                _sizeDAL.Update(deletedEntity);
                return new SuccessResult(CommonMessages.DATA_DELETED_SUCCESSFULLY);
            }
            return new ErrorResult(CommonMessages.DATA_NOT_FOUND_FOR_DELETE);
        }

        public IDataResult<List<Size>> GetAll()
        {
            return new SuccessDataResult<List<Size>>(_sizeDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Size> GetById(int id)
        {
            return new SuccessDataResult<Size>(_sizeDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Size model)
        {
            #region Validate Model

            var validation = new SizeValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _sizeDAL.Update(model);
            return new SuccessResult(CommonMessages.DATA_UPDATED_SUCCESSFULLY);
        }
    }
}
