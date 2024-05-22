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
    public class UserManager : ManagerBase<User, IUserDal>
    {
        public UserManager(IUserDal dataDal) : base(dataDal)
        {

        }

        [ValidationAspect(typeof(UserValidator))]
        public override IResult Add(User entity)
        {
            return base.Add(entity);
        }
    }
}
