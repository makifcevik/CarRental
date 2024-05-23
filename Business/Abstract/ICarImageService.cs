using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IResult Add(IFormFile file, CarImage entity);
        public IDataResult<CarImage> Get(Expression<Func<CarImage, bool>> filter);
        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null);
        public IDataResult<CarImage> GetByImageId(int imageId);
        public IResult Update(IFormFile file, CarImage entity);
        public IResult Delete(CarImage entity);
    }
}
