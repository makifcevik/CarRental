﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
        [SecuredOperation("user.add,user.admin,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult();
        }

        [SecuredOperation("user.delete,user.admin,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult();
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter));
        }

        [PerformanceAspect]
        [CacheAspect]
        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(filter));
        }

        [PerformanceAspect]
        [CacheAspect]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [SecuredOperation("user.update,user.admin,admin")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult();
        }

    }
}
