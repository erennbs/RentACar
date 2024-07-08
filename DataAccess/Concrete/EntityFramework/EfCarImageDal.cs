using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImageDal {
        public CarImage UploadImage(int carId, IFormFile file) {
            string uploadsFolderPath = "C:\\Users\\lenovo\\source\\repos\\RentACar\\DataAccess\\Uploads\\";

            if (!Directory.Exists(uploadsFolderPath)) {
                Directory.CreateDirectory(uploadsFolderPath);   
            }

            string extension = Path.GetExtension(file.FileName);
            string fileName = Guid.NewGuid().ToString() + extension;
            string filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var fileStream = File.Create(filePath)) {
                file.CopyTo(fileStream);
            }

            return new CarImage { CarId = carId, Date = DateTime.Now , ImagePath = filePath};
        }

        public CarImage UpdateImage(CarImage carImage, IFormFile file) {
            if (!DeleteImage(carImage)) {
                return null;
            }
            return UploadImage(carImage.CarId, file);

        }

        public bool DeleteImage(CarImage carImage) {
            if (!File.Exists(carImage.ImagePath)) {
                return false;
            }
            File.Delete(carImage.ImagePath);
            return true;
        }

    }
}
