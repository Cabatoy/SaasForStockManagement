using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator : AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(p => p.TaxNumber).NotEmpty().WithMessage(Messages.TaxNumberValidationError);
            RuleFor(p => p.TaxNumber).Length(10, 11).WithMessage(Messages.TaxNumberLengtValidationError);
            RuleFor(p => p.Email).NotEmpty().WithMessage(Messages.EmailCanNotBlank);
        }
    }
}
