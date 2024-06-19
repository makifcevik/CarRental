using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
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
    public class RentalManager : ManagerBase<Rental, IRentalDal>, IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal) : base(rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("rental.add,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public override IResult Add(Rental entity)
        {
            return base.Add(entity);
        }
        public bool IsAvaliable(int CarId)
        {
            DateTime returnDate = _rentalDal.Get(r => r.CarId == CarId).ReturnDate;
            if (DateTime.Now < returnDate) 
            {
                return false;
            }
            return true;
        }
    }
}
