using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach(var car in carManager.GetAllCarDetailDtos())
        {
            Console.WriteLine("{0}   {1}   {2}   {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
        }
    }
}