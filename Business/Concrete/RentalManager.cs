using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService{
        private readonly IRentalDal _rentalDal;
        private readonly IPaymentService _paymentService;


        public RentalManager(IRentalDal rentalDal, IPaymentService paymentService) {
            _rentalDal = rentalDal;
            _paymentService = paymentService;
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental) {
            var result = BusinessRules.Run(CheckIfCarIsAvailable(rental));

            if (result != null) {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental) {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll() {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailsDto>> GetAllWithDetails() {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalsWithDetails(), Messages.RentalsListed);
        }

        public IDataResult<DateTime> GetAvailableDate(int carId) {
            DateTime date;
            
            var result = _rentalDal.GetAll(p => p.CarId == carId && p.ReturnDate > DateTime.Now).LastOrDefault();
            
            if (result != null) {
                date = result.ReturnDate;

            } else {
                date = DateTime.Now;
            }

            return new SuccessDataResult<DateTime>(date);
        }

        

        public IResult Update(Rental rental) {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckIfCarIsAvailable(Rental rental) {
            var result = _rentalDal.Get(r => r.RentDate >= rental.RentDate && r.RentDate <= rental.ReturnDate);
            if (result != null) {
                return new ErrorResult(Messages.RentalNotReturned);
            }
            return new SuccessResult();
        }
    }
}
