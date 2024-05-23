using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        public IResult Add(Car entity);
        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter);
        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null);
        public IResult Update(Car entity);
        public IResult Delete(Car entity);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<CarDetailDto>> GetAllCarDetailDtos();
    }
}
