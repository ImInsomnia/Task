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
    public class CountryManager : ICountryService
    {
        private readonly ICountryDAL _countryDAL;
        public CountryManager()
        {
            _countryDAL = new CountryDAL();
        }
        public IResult Add(Country model)
        {
            #region Validate Model

            var validation = new CountryValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _countryDAL.Add(model);
            return new SuccessResult(CommonMessages.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult Delete(Country model)
        {
            var deletedEntity = _countryDAL.Get(x => x.ID == model.ID);
            if (deletedEntity != null)
            {
                deletedEntity.Deleted = model.ID;
                _countryDAL.Update(deletedEntity);
                return new SuccessResult(CommonMessages.DATA_DELETED_SUCCESSFULLY);
            }
            return new ErrorResult(CommonMessages.DATA_NOT_FOUND_FOR_DELETE);
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDAL.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Country> GetById(int id)
        {
            return new SuccessDataResult<Country>(_countryDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Country model)
        {
            #region Validate Model

            var validation = new CountryValidation();
            var validationResult = validation.Validate(model);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorsToString());

            #endregion

            _countryDAL.Update(model);
            return new SuccessResult(CommonMessages.DATA_UPDATED_SUCCESSFULLY);
        }
    }
}
