using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 20000, ModelYear = 2020, Description = "" },
                new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 30000, ModelYear = 2022, Description = "" },
                new Car { Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 15000, ModelYear = 2019, Description = "" },
                new Car { Id = 4, BrandId = 3, ColorId = 2, DailyPrice = 50000, ModelYear = 2023, Description = "" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carFound = _cars.Where(c => c.Id == car.Id).SingleOrDefault();

            if (carFound != null)
            {
                _cars.Remove(carFound);
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.Where(c => c.Id == id).SingleOrDefault();
        }

        public void Update(Car car)
        {
            Car carFound = _cars.Where(c => c.Id == car.Id).SingleOrDefault();

            if (carFound != null)
            {
                carFound.Id = car.Id;
                carFound.BrandId = car.BrandId;
                carFound.ColorId = car.ColorId;
                carFound.ModelYear = car.ModelYear;
                carFound.DailyPrice = car.DailyPrice;
                carFound.Description = car.Description;
            }
        }
    }
}
