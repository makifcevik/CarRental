using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        //CarDtoTest();
        ColorManager colorManager = new ColorManager(new EfColorDal());
        foreach (var color in colorManager.GetAll().Data)
        {
            Console.WriteLine(color.Name);
        }
    }

    private static void CarDtoTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetAllCarDetailDtos().Data)
        {
            Console.WriteLine("{0}   {1}   {2}   {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
        }
    }
}