using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllCarDetails(int? brandId = null, int? colorId = null);
        CarDetailDto GetCarDetails(int id);
        List<CarDetailDto> GetAllCarDetailsByBrandId(int brandId);
        List<CarDetailDto> GetAllCarDetailsByColorId(int colorId);
    }
}
