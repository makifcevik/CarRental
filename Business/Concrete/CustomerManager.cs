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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ManagerBase<Customer, ICustomerDal>, ICustomerService
    {
        public CustomerManager(ICustomerDal dataDal) : base(dataDal)
        {

        }

        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public override IResult Add(Customer entity)
        {
            return base.Add(entity);
        }
    }
}
