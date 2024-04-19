using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation {
    public class CarValidator : AbstractValidator<Car>{
        public CarValidator() {
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(1800);
            RuleFor(p => p.Description).MinimumLength(2).WithMessage(Messages.InvalidCarName);
            RuleFor(P => P.DailyPrice).GreaterThanOrEqualTo(0).WithMessage(Messages.InvalidCarPrice);
        }
    }
}
