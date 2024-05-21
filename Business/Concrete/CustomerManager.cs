using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ManagerBase<Customer, ICustomerDal>
    {
        public CustomerManager(ICustomerDal dataDal) : base(dataDal)
        {

        }
    }
}
