using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
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
    public abstract class ManagerBase<T, TDataDal> : IManagerService<T>
        where T : class, IEntity, new()
        where TDataDal : IEntityRepository<T>
    {
        private TDataDal _dataDal;
        public ManagerBase(TDataDal dataDal)
        {
            _dataDal = dataDal;
        }

        public virtual IResult Add(T entity)
        {
            _dataDal.Add(entity);
            return new SuccessResult();
        }
        public virtual IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return new SuccessDataResult<List<T>>(_dataDal.GetAll(filter));
        }
        public virtual IDataResult<T> Get(Expression<Func<T, bool>> filter)
        {
            return new SuccessDataResult<T>(_dataDal.Get(filter));
        }
        public virtual IResult Delete(T Entity)
        {
            _dataDal.Delete(Entity);
            return new SuccessResult();
        }
        public virtual IResult Update(T Entity)
        {
            _dataDal.Update(Entity);
            return new SuccessResult();
        }
    }
}
