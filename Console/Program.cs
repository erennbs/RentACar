using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;


internal class Program {
    private static void Main(string[] args) {
        CarManager carManager = new CarManager(new EfCarDal());
        
        foreach (CarDetailsDto car in carManager.GetCarWithDetails())
        {
            Console.WriteLine($"{car.CarName} - {car.ColorName} - {car.BrandName} - {car.DailyPrice}TL");
        }
    }

    private static void BrandTest() {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        //brandManager.Add(new Brand { Id = 7, Name = "Volkswagen" });
        //brandManager.Update(new Brand { Id = 7, Name = "Ferrari" });
        //brandManager.Delete(new Brand { Id = 7, Name = "Ferrari" });


        foreach (Brand brand in brandManager.GetAll()) {
            Console.WriteLine(brand.Name);
        }
    }

    private static void ColorTest() {
        ColorManager colorManager = new ColorManager(new EfColorDal());

        //colorManager.Add(new Color { Id = 6, Name = "Mor" });
        //colorManager.Update(new Color { Id = 6, Name = "Fuşya" });
        //colorManager.Delete(new Color { Id = 6, Name = "Fuşya" });

        foreach (Color color in colorManager.GetAll()) {
            Console.WriteLine(color.Name);
        }
    }

    static void CarTest() {
        //InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
        EfCarDal efCarDal = new EfCarDal();

        //efCarDal.Add(new Car {BrandId = 3, ColorId = 1, DailyPrice = 6000, ModelYear = 2021, Description = "new car" });
        //efCarDal.Delete(new Car { Id = 8, BrandId = 3, ColorId = 1, DailyPrice = 6000, ModelYear = 2021, Description = "new car" });

        efCarDal.Update(new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 1200, ModelYear = 2021, Description = "Hyundai i30 2015" });

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