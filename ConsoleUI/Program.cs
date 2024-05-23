using Business.Concrete;
using Core.Utilities.Helpers.FileHelpers;
using DataAccess.Concrete.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        //CarDtoTest();
        //ColorManager colorManager = new ColorManager(new EfColorDal());
        //foreach (var color in colorManager.GetAll().Data)
        //{
        //    Console.WriteLine(color.Name);
        //}
        CarImageManager manager = new CarImageManager(new EfCarImageDal(), new FileHelperManager());
        var result = manager.GetByImageId(1);
        Console.WriteLine(result.Data.ImageName);
        Console.ReadLine();
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