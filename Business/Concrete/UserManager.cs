using Business.Abstract;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal dataDal)
        {
            _userDal = dataDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter));
        }

        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(filter));
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
