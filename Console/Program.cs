using Business.Concrete;
using Core.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;


internal class Program {
    private static void Main(string[] args) {
        CarTest();
    }

    private static void CarDetailTest() {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (CarDetailsDto car in carManager.GetCarWithDetails().Data) {
            Console.WriteLine($"{car.CarName} - {car.ColorName} - {car.BrandName} - {car.DailyPrice}TL");
        }
    }

    private static void BrandTest() {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        //brandManager.Add(new Brand { Id = 7, Name = "Volkswagen" });
        //brandManager.Update(new Brand { Id = 7, Name = "Ferrari" });
        //brandManager.Delete(new Brand { Id = 7, Name = "Ferrari" });


        foreach (Brand brand in brandManager.GetAll().Data) {
            Console.WriteLine(brand.Name);
        }
    }

    private static void ColorTest() {
        ColorManager colorManager = new ColorManager(new EfColorDal());

        //IResult result = colorManager.Add(new Color { Id = 6, Name = "Mor" });
        //IResult result = colorManager.Delete(new Color { Id = 6, Name = "Fuşya" });
        //Console.WriteLine(result.Success);
        //Console.WriteLine(result.Message);


        //colorManager.Update(new Color { Id = 6, Name = "Fuşya" });

        foreach (Color color in colorManager.GetAll().Data) {
            Console.WriteLine(color.Name);
        }
    }

    static void CarTest() {
        //InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
        EfCarDal efCarDal = new EfCarDal();
        CarManager carManager = new CarManager(efCarDal);

        //IResult result = carManager.Add(new Car { BrandId = 3, ColorId = 1, DailyPrice = 6000, ModelYear = 2021, Description = "a" });
        //Console.WriteLine(result.Success);
        //Console.WriteLine(result.Message);

        //efCarDal.Delete(new Car { Id = 8, BrandId = 3, ColorId = 1, DailyPrice = 6000, ModelYear = 2021, Description = "new car" });

        //efCarDal.Update(new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 1200, ModelYear = 2021, Description = "Hyundai i30 2015" });

        foreach (Car car in efCarDal.GetAll()) {
            Console.WriteLine($"{car.Id} - {car.DailyPrice} - {car.Description}");
        }

        //Console.WriteLine(efCarDal.Get(p => p.Id == 2).Id);

        //efCarDal.Delete(new Car { Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 15000, ModelYear = 2019, Description = "" });

        //foreach (Car car in efCarDal.GetAll()) {
        //    Console.WriteLine(car.DailyPrice);
        //}
    }
}