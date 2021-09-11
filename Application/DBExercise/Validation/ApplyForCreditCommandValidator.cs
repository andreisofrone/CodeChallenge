using Application.Common.Repositories.Contracts;
using Application.DBExercise.Messages.Commands;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace Application.DBExercise.Validation
{
    public class ApplyForCreditCommandValidator
     : AbstractValidator<ApplyForCreditCommand>
    {
        private const long maxAmount = 1000000000;

        public ApplyForCreditCommandValidator(ITotalFutureDebtRepository totalFutureDebtRepository)
        {
            RuleFor(cp => cp.CreditAmount)
                    .NotNull().WithMessage(cp => $"{nameof(cp.CreditAmount)} is required.")
                    .GreaterThan(0).WithMessage(cp => $"{nameof(cp.CreditAmount)} must be greater than 0.")
                    .LessThanOrEqualTo(maxAmount).WithMessage(cp => $"{nameof(cp.CreditAmount)} must be less than 1000000000.");

            RuleFor(cp => cp.CurrentPreExistingCreditAmount)
                   .NotNull().WithMessage(cp => $"{nameof(cp.CurrentPreExistingCreditAmount)} is required.")
                   .GreaterThan(0).WithMessage(cp => $"{nameof(cp.CurrentPreExistingCreditAmount)} must be greater than 0.")
                   .LessThanOrEqualTo(maxAmount).WithMessage(cp => $"{nameof(cp.CurrentPreExistingCreditAmount)} must be less than 1000000000.");

            RuleFor(cp => cp.Term)
                   .NotNull().WithMessage(cp => $"{nameof(cp.Term)} is required.")
                   .GreaterThan(0).WithMessage(cp => $"{nameof(cp.Term)} must be greater than 0.")
                   .LessThanOrEqualTo(maxAmount).WithMessage(cp => $"{nameof(cp.Term)} must be less than 1000000000.");

            RuleFor(c => c).CustomAsync(async (c, ctx, token) =>
            {

                var totalFutureDebt = c.CreditAmount + c.CurrentPreExistingCreditAmount;
                var totalFutureDebtRange = (await totalFutureDebtRepository.GetAll())
                                                 .FirstOrDefault(am => totalFutureDebt >= am.LowerBound && totalFutureDebt < am.UpperBound);

                if(totalFutureDebtRange == null)
                    ctx.AddFailure(new ValidationFailure("Total future debt", "Interest rate is not available for the total future debt."));

            });
        }
    }
}
