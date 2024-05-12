using Business.Abstract;
using Core.Business;
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
    public class ColorManager : ManagerBase<Color, IColorDal>, IColorService
    {
        public ColorManager(IColorDal colorDal) : base(colorDal)
        {

        }
    }
}
