using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public interface IManagerService<T> where T : class, IEntity, new()
    {
        public IResult Add(T entity);
        public IDataResult<T> Get(Expression<Func<T, bool>> filter);
        public IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        public IResult Update(T entity);
        public IResult Delete(T entity);
    }
}
