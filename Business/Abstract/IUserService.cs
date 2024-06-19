using Core.Entities.Concrete;
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
        public IResult Add(User entity);
        public IDataResult<User> Get(Expression<Func<User, bool>> filter);
        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        public IResult Update(User entity);
        public IResult Delete(User entity);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
