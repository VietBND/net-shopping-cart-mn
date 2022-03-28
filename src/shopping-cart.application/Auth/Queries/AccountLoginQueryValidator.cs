using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart.application.Auth.Queries
{
    public class AccountLoginQueryValidator : AbstractValidator<AccountLoginQueries>
    {
        public AccountLoginQueryValidator()
        {
            RuleFor(s => s.Username).NotNull().WithMessage("USERNAME_CAN_NOT_NULL").NotEmpty().WithMessage("USERNAME_CAN_NOT_EMPTY");
            RuleFor(s => s.Password).NotNull().WithMessage("PASSWORD_CAN_NOT_NULL").NotEmpty().WithMessage("PASSWORD_CAN_NOT_EMPTY");
        }
    }
}
