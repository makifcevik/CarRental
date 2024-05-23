using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public IResult Add(Customer entity);
        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter);
        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null);
        public IResult Update(Customer entity);
        public IResult Delete(Customer entity);
    }
}
