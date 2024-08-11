using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("rental.add,rental.admin,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult();
        }

        [SecuredOperation("rental.delete,rental.admin,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(filter));
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter));
        }

        [PerformanceAspect]
        public bool IsAvaliable(int CarId)
        {
            DateTime returnDate = _rentalDal.Get(r => r.CarId == CarId).ReturnDate;
            if (DateTime.Now < returnDate) 
            {
                return false;
            }
            return true;
        }

        [SecuredOperation("rental.update,rental.admin,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }
    }
}
