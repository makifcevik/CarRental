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
    public interface IBrandService
    {
        public IResult Add(Brand entity);
        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter);
        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null);
        public IResult Update(Brand entity);
        public IResult Delete(Brand entity);
    }
}
