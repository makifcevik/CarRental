using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter));
        }

        [SecuredOperation("car.add,car.admin,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarNameExists(car.Name));
            if(result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult();     
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails());
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter));
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.update,car.admin,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult();
        }

        [SecuredOperation("car.delete,car.admin,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult();
        }
        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(c => c.Name == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetailsByBrandId(brandId));
        }

        [CacheAspect]
        [PerformanceAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetailsByColorId(colorId));
        }
    }
}
