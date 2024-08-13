using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class CarImageManager : ICarImageService {
        ICarImageDal _carImageDal;
        IHostingEnvironment _env;

        public CarImageManager(ICarImageDal carImageDal, IHostingEnvironment hostingEnvironment) {
            _carImageDal = carImageDal;
            _env = hostingEnvironment;
        }


        public IResult Add(CarImage carImage, IFormFile file) {
            IResult result = BusinessRules.Run(CheckIfImageAmountExceeds(carImage.Id));

            if (result != null) {
                return result;
            }
            
            carImage.ImagePath = FileHelper.Upload(file, Path.Combine(_env.WebRootPath, "uploads"));
            if (carImage.ImagePath == null) {
                return new ErrorResult(Messages.CarImageUploadError);
            }
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(int id) {
            CarImage imageToDelete = _carImageDal.Get(p => p.Id == id);
            if (!FileHelper.Delete(Path.Combine(_env.WebRootPath, "uploads", imageToDelete.ImagePath))) {
                return new ErrorResult(Messages.CarImageNoFileExists);
            }
            _carImageDal.Delete(imageToDelete);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId) {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count == 0) {
                result.Add(new CarImage { CarId = carId , ImagePath = "default.jpg" });
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult DeleteByCarId(int carId) {
            var result = _carImageDal.GetAll(image => image.CarId == carId);
            foreach (var carImage in result)
            {
                if (!FileHelper.Delete(Path.Combine(_env.WebRootPath, "uploads", carImage.ImagePath))) {
                    return new ErrorResult(Messages.CarImageNoFileExists);
                }
                _carImageDal.Delete(carImage);
            }

            return new SuccessResult();
        }

        public IResult Update(CarImage carImage, IFormFile file) {
            carImage.ImagePath = FileHelper.Update(file, carImage.ImagePath, Path.Combine(_env.WebRootPath, "uploads"));
            
            if (carImage == null) {
                return new ErrorResult(Messages.CarImageNoFileExists);
            }
            
            _carImageDal.Update(carImage);
            
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
