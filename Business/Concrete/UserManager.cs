using Core.Business;
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
    }
}
