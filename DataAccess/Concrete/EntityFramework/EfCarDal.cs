using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails(int? brandId = null, int? colorId = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = CreateCarDetailsQuery(context, brandId, colorId);
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetails(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = CreateCarDetailsQuery(context).Where(carDto => carDto.CarId == id);
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetAllCarDetailsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = CreateCarDetailsQuery(context, brandId: brandId);
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetAllCarDetailsByColorId(int colorId)
        {
            using (CarRentalContext context= new CarRentalContext())
            {
                var result = CreateCarDetailsQuery(context, colorId: colorId);
                return result.ToList();
            }
        }

        private IQueryable<CarDetailDto> CreateCarDetailsQuery(CarRentalContext context, int? brandId = null, int? colorId = null)
        {
            var query = from car in context.Cars
                        join brand in context.Brands on car.BrandId equals brand.Id
                        join color in context.Colors on car.ColorId equals color.Id
                        join image in context.CarImages on car.Id equals image.CarId into carImages
                        where(!brandId.HasValue || car.BrandId == brandId.Value)
                          && (!colorId.HasValue || car.ColorId == colorId.Value)
                        select new CarDetailDto
                        {
                            CarId = car.Id,
                            CarName = car.Name,
                            BrandName = brand.Name,
                            ColorName = color.Name,
                            DailyPrice = car.DailyPrice,
                            Images = carImages.Any()
                                ? carImages.Select(img => img.ImageName).ToList()
                                : new List<string> { "default.jpg" }
                        };
            return query;
        }
    }

}
