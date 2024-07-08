using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract {
    public interface ICarImageDal : IEntityRepository<CarImage>{
        CarImage UploadImage(int carId, IFormFile file);
        CarImage UpdateImage(CarImage carImage, IFormFile file);        
        bool DeleteImage(CarImage carImage);

    }
}
