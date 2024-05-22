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
    public class CityManager : ICityService
    {
        private readonly ICityDAL _cityDAL;
        public CityManager()
        {
            _cityDAL = new CityDAL();
        }
        public IResult Add(City model)
        {
            #region Validate Model

            var validation = new CityValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _cityDAL.Add(model);
            return new SuccessResult(CommonMessages.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult Delete(City model)
        {
            var deletedEntity = _cityDAL.Get(x => x.ID == model.ID);
            if (deletedEntity != null)
            {
                deletedEntity.Deleted = model.ID;
                _cityDAL.Update(deletedEntity);
                return new SuccessResult(CommonMessages.DATA_DELETED_SUCCESSFULLY);
            }
            return new ErrorResult(CommonMessages.DATA_NOT_FOUND_FOR_DELETE);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(City model)
        {
            #region Validate Model

            var validation = new CityValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _cityDAL.Update(model);
            return new SuccessResult(CommonMessages.DATA_UPDATED_SUCCESSFULLY);
        }
    }
}
