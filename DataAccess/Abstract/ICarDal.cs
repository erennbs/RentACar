using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract {
    public interface ICarDal : IEntityRepository<Car> {
        public List<CarDetailsDto> GetCarsWithDetails(string brandName, string colorName, string startDate, string endDate);
        public List<CarDetailsDto> GetCarsDetailsByBrand(int brandId);
        public List<CarDetailsDto> GetCarsDetailsByColor(int colorId);
        public CarDetailsDto GetDetailsById(int carId);
    }
}
