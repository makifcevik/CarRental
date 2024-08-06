using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(filter));
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(filter));
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
