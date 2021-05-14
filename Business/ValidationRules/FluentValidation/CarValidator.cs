using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(3).WithMessage("Description must be at least 3 chars. ");
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(15);
            RuleFor(c => c.ModelYear).NotEmpty();
        }
    }
}
