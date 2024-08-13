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
        public List<CarDetailsDto> GetCarsWithDetails(string brandName, string colorName, string startDate, string endDate) {
            using (RentACarContext context = new RentACarContext()) {
                var results = from car in context.Cars
                              join color in context.Colors on car.ColorId equals color.Id
                              join brand in context.Brands on car.BrandId equals brand.Id
                              select new CarDetailsDto {
                                  Id = car.Id,
                                  CarName = car.Description,
                                  BrandName = brand.Name,
                                  ColorName = color.Name,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  ImagePath = context.CarImages
                                                .Where(image => image.CarId == car.Id)
                                                .Select(image => image.ImagePath)
                                                .FirstOrDefault() ?? "default.jpg",
                                  IsAvailable = !context.Rentals
                                                    .Any(rental => rental.CarId == car.Id && rental.ReturnDate > DateTime.Now)
                              };

                if (!string.IsNullOrEmpty(brandName)) {
                    results = results.Where(c => c.BrandName == brandName);
                }
                if (!string.IsNullOrEmpty(colorName)) {
                    results = results.Where(c => c.ColorName == colorName);
                }
                if (!string.IsNullOrEmpty(startDate) &&  !string.IsNullOrEmpty(endDate)) {
                    results = results.Where(car => !context.Rentals
                    .Any(rental => rental.CarId == car.Id
                        && (rental.RentDate <= DateTime.Parse(endDate) && rental.ReturnDate >= DateTime.Parse(startDate))
                         ));
                }

                return results.ToList();
            }
        }
        public List<CarDetailsDto> GetCarsDetailsByBrand(int brandId) {
            using (RentACarContext context = new RentACarContext()) {
                var results = from car in context.Cars
                              join color in context.Colors
                              on car.ColorId equals color.Id
                              join brand in context.Brands
                              on car.BrandId equals brand.Id
                              where brand.Id == brandId
                              select new CarDetailsDto {
                                  Id = car.Id,
                                  CarName = car.Description,
                                  BrandName = brand.Name,
                                  ColorName = color.Name,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  ImagePath = context.CarImages
                                                .Where(image => image.CarId == car.Id)
                                                .Select(image => image.ImagePath)
                                                .FirstOrDefault() ?? "default.jpg",
                                  IsAvailable = !context.Rentals
                                                    .Any(rental => rental.CarId == car.Id && rental.ReturnDate > DateTime.Now)
                              };

                return results.ToList();
            }
        }

        public List<CarDetailsDto> GetCarsDetailsByColor(int colorId) {
            using (RentACarContext context = new RentACarContext()) {
                var results = from car in context.Cars
                              join color in context.Colors
                              on car.ColorId equals color.Id
                              join brand in context.Brands
                              on car.BrandId equals brand.Id
                              where color.Id == colorId
                              select new CarDetailsDto {
                                  Id = car.Id,
                                  CarName = car.Description,
                                  BrandName = brand.Name,
                                  ColorName = color.Name,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  ImagePath = context.CarImages
                                                .Where(image => image.CarId == car.Id)
                                                .Select(image => image.ImagePath)
                                                .FirstOrDefault() ?? "default.jpg",
                                  IsAvailable = !context.Rentals
                                                    .Any(rental => rental.CarId == car.Id && rental.ReturnDate > DateTime.Now)
                              };

                return results.ToList();
            }
        }

        public CarDetailsDto GetDetailsById(int carId) {
            using (RentACarContext context = new RentACarContext()) {
                var results = from car in context.Cars
                              join color in context.Colors
                              on car.ColorId equals color.Id
                              join brand in context.Brands
                              on car.BrandId equals brand.Id
                              where car.Id == carId
                              select new CarDetailsDto {
                                  Id = car.Id,
                                  CarName = car.Description,
                                  BrandName = brand.Name,
                                  ColorName = color.Name,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  ImagePath = context.CarImages
                                                .Where(image => image.CarId == car.Id)
                                                .Select(image => image.ImagePath)
                                                .FirstOrDefault() ?? "default.jpg",
                                  IsAvailable = !context.Rentals
                                                    .Any(rental => rental.CarId == car.Id && rental.ReturnDate > DateTime.Now)
                              };

                return results.FirstOrDefault();
            }
        }


        //public List<Car> GetAvailableCars(DateTime startDate, DateTime endDate) {
        //    using (RentACarContext context = new RentACarContext()) {
        //        var availableCars = context.Cars
        //        .Where(car => !context.Rentals
        //            .Any(rental => rental.CarId == car.Id
        //                && (rental.RentDate <= endDate && rental.ReturnDate >= startDate)
        //                 ))
        //        .ToList();

        //        return availableCars;
        //    }
        //}
    }
}
