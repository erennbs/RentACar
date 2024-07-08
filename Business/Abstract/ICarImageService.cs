using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract {
    public interface ICarImageService {
        public IResult Add(int carId, IFormFile file);
        public IResult Delete(int id);
        public IResult Update(int id, IFormFile file);
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId);
    }
}
