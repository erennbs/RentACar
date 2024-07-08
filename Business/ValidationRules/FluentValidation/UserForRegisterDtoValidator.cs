using Business.Constants;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation {
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto> {
        public UserForRegisterDtoValidator() {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Email).Must(ValidateEmail).WithMessage(Messages.InvalidUserEmail);
            RuleFor(p => p.Password).MinimumLength(8);
        }

        public bool ValidateEmail(string txt) {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(txt);
        }
    }
}
