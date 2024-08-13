using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService {

        private ICarDal _carDal;

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IDataResult<Car> Add(Car car) {
            _carDal.Add(car);
            return new SuccessDataResult<Car>(car, Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car) {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        //[SecuredOperation("cars.list,admin")]
        [CacheAspect()]
        public IDataResult<List<Car>> GetAll() {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int brandId) {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetailsByBrand(brandId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorId) {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetailsByColor(colorId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsWithDetails(string brand, string color, string startDate, string endDate) {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsWithDetails(brand, color, startDate, endDate));
        }
        
        public IDataResult<CarDetailsDto> GetDetailsById(int id) {
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetDetailsById(id));
        }

        public IDataResult<Car> GetById(int id) {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car) {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
