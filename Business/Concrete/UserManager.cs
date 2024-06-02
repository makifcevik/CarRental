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

        public IResult Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
