// See https://aka.ms/new-console-template for more information

using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

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