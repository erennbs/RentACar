﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation {
    public class RentalValidator : AbstractValidator<Rental>{
        public RentalValidator() {
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.RentDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(p => p.ReturnDate).NotEmpty().GreaterThanOrEqualTo(p => p.RentDate);
        }
    }
}
