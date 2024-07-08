using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService{
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal) {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(Rental))]
        public IResult Add(Rental rental) {
            var result = BusinessRules.Run(CheckIfCarHasReturned(rental.CarId));

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

        public IResult Update(Rental rental) {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        private IResult CheckIfCarHasReturned(int carId) {
            Rental result = _rentalDal.Get(p => p.CarId == carId);
            if (result != null && result.ReturnDate == null) {
                return new ErrorResult(Messages.RentalNotReturned);
            }
            return new SuccessResult();
        }
    }
}
