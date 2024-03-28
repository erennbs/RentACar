using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Business.Concrete {
    public class CarManager : ICarService {

        private ICarDal _carDal;

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public void Add(Car car) {
            if (car.Description.Length > 2 && car.DailyPrice > 0) {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car) {
            _carDal.Delete(car);
        }

        public List<Car> GetAll() {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id) {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id) {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<CarDetailsDto> GetCarWithDetails() {
            return _carDal.GetCarsWithDetails();
        }

        public void Update(Car car) {
            _carDal.Update(car);
        }
    }
}
