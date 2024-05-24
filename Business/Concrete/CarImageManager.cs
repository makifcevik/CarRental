using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage entity)
        {
            var result = BusinessRules.Run(
                CheckIfExceedsImageLimit(entity.CarId));
            if(result != null)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            entity.ImageName = _fileHelper.Upload(file, PathConstants.ImagePath);
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            _fileHelper.Delete(Path.Combine(PathConstants.ImagePath, entity.ImageName));
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(Expression<Func<CarImage, bool>> filter)
        {
            var result = _carImageDal.Get(filter);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            var result = _carImageDal.GetAll(filter);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            var result = _carImageDal.Get(c => c.Id == imageId);
            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }
            return new ErrorDataResult<CarImage>();
        }


        public IResult Update(IFormFile file, CarImage entity)
        {
            _fileHelper.Update(file, entity.ImageName, PathConstants.ImagePath);
            _carImageDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckIfExceedsImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
