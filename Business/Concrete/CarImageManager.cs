using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class CarImageManager : ICarImageService {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal) {
            _carImageDal = carImageDal;
        }


        public IResult Add(int carId, IFormFile file) {
            IResult result = BusinessRules.Run(CheckIfImageAmountExceeds(carId));

            if (result != null) {
                return result;
            }

            CarImage carImage = _carImageDal.UploadImage(carId, file);
            if (carImage == null) {
                return new ErrorResult(Messages.CarImageUploadError);
            }
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(int id) {
            CarImage imageToDelete = _carImageDal.Get(p => p.Id == id);
            if (!_carImageDal.DeleteImage(imageToDelete)) {
                return new ErrorResult(Messages.CarImageNoFileExists);
            }
            _carImageDal.Delete(imageToDelete);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId) {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count == 0) {
                result.Add(new CarImage { CarId = carId , ImagePath = "C:\\Users\\lenovo\\source\\repos\\RentACar\\DataAccess\\Uploads\\default.jpg" });
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(int id, IFormFile file) {
            CarImage carImage = _carImageDal.Get(p =>  p.Id == id);
            CarImage newCarImage = _carImageDal.UpdateImage(carImage, file);
            
            if (newCarImage == null) {
                return new ErrorResult(Messages.CarImageNoFileExists);
            }
            newCarImage.Id = id;
            _carImageDal.Update(newCarImage);
            
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfImageAmountExceeds(int carId) {
            // Every car can have max 5 image
            var result = _carImageDal.GetAll(p => p.CarId == carId ).Count;

            if (result == 5) {
                return new ErrorResult(Messages.ImageAmountExceeds);
            }

            return new SuccessResult();
        }
    }
}
