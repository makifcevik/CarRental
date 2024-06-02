using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.PasswordHash).NotEmpty();
            RuleFor(c => c.PasswordSalt).NotEmpty();
            RuleFor(c => c.Status).NotNull();
            RuleFor(c => c.FirstName).MinimumLength(3);
            RuleFor(c => c.LastName).MinimumLength(3);
            RuleFor(c => c.CompanyName).NotEmpty();
        }
    }
}
