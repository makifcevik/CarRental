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
    public interface IUserService
    {
        public IResult Add(Rental entity);
        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter);
        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null);
        public IResult Update(Rental entity);
        public IResult Delete(Rental entity);
    }
}
