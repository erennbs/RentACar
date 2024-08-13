using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework {
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal {
        public List<RentalDetailsDto> GetRentalsWithDetails() {
            using (RentACarContext context = new RentACarContext()) {
                var result = from rentals in context.Rentals
                             join cars in context.Cars
                             on rentals.CarId equals cars.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             join users in context.Users
                             on rentals.UserId equals users.Id

                             select new RentalDetailsDto {
                                 Id = rentals.Id,
                                 BrandName = brands.Name, 
                                 CustomerName = $"{users.FirstName} {users.LastName}", 
                                 RentDate = rentals.RentDate, 
                                 ReturnDate = rentals.ReturnDate};

                return result.ToList();
            }
        }
    }
}
