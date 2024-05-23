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
    public interface IColorService
    {
        public IResult Add(Color entity);
        public IDataResult<Color> Get(Expression<Func<Color, bool>> filter);
        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null);
        public IResult Update(Color entity);
        public IResult Delete(Color entity);
    }
}
