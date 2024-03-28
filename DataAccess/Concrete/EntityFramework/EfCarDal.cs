using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal {
        public List<CarDetailsDto> GetCarsWithDetails() {
            using (RentACarContext context = new RentACarContext()) {
                var results = from car in context.Cars
                              join color in context.Colors
                              on car.ColorId equals color.Id
                              join brand in context.Brands
                              on car.BrandId equals brand.Id
                              select new CarDetailsDto {
                                  CarName = car.Description,
                                  BrandName = brand.Name,
                                  ColorName = color.Name,
                                  DailyPrice = car.DailyPrice
                              };

                return results.ToList();
            }
        }
    }
}
