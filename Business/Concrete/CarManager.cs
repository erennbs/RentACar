using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Results;
using Business.Constants;

namespace Business.Concrete {
    public class CarManager : ICarService {

        private ICarDal _carDal;

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public IResult Add(Car car) {
            if (car.Description.Length < 2) {
                return new ErrorResult(Messages.InvalidCarName);
            } else if (car.DailyPrice < 0) {
                return new ErrorResult(Messages.InvalidCarPrice);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car) {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll() {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailsDto>> GetCarWithDetails() {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsWithDetails());
        }

        public IResult Update(Car car) {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
