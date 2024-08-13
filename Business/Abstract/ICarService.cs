using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService {
        IDataResult<Car> Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailsDto>> GetCarsByColorId(int id);
        IDataResult<CarDetailsDto> GetDetailsById(int id);
        IDataResult<List<CarDetailsDto>> GetCarsWithDetails(string brandName, string colorName, string startDate, string endDate);
    }
}
