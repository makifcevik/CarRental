using Business.Abstract;
using Core.Business;
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
