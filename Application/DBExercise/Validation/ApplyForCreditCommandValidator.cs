using Application.Common.Repositories.Contracts;
using Application.DBExercise.Messages.Commands;
using FluentValidation;
using System.Linq;

namespace Application.DBExercise.Validation
{
    public class ApplyForCreditCommandValidator
     : AbstractValidator<ApplyForCreditCommand>
    {
        private const long maxAmount = 1000000000;

        public ApplyForCreditCommandValidator(IAppliedAmountRepository appliedAmountRepository)
        {
            RuleFor(cp => cp.CreditAmount)
                    .NotNull().WithMessage(cp => $"{nameof(cp.CreditAmount)} is required.")
                    .GreaterThan(0).WithMessage(cp => $"{nameof(cp.CreditAmount)} must be greater than 0.")
                    .LessThanOrEqualTo(maxAmount).WithMessage(cp => $"{nameof(cp.CreditAmount)} must be less than 1000000000.")
                     .DependentRules(() =>
                     {
                         RuleFor(c => c).MustAsync(async (c, token) =>
                         {
                             var isValid = (await appliedAmountRepository.GetAll()).Any(am => c.CreditAmount > am.LowerBound && c.CreditAmount < am.UpperBound);
                             return isValid;

                         })
                         .WithMessage(c => "Value not allowed.");
                     }); ;

            RuleFor(cp => cp.CurrentPreExistingCreditAmount)
                   .NotNull().WithMessage(cp => $"{nameof(cp.CurrentPreExistingCreditAmount)} is required.")
                   .GreaterThan(0).WithMessage(cp => $"{nameof(cp.CurrentPreExistingCreditAmount)} must be greater than 0.")
                   .LessThanOrEqualTo(maxAmount).WithMessage(cp => $"{nameof(cp.CurrentPreExistingCreditAmount)} must be less than 1000000000.");

            RuleFor(cp => cp.Term)
                   .NotNull().WithMessage(cp => $"{nameof(cp.Term)} is required.")
                   .GreaterThan(0).WithMessage(cp => $"{nameof(cp.Term)} must be greater than 0.")
                   .LessThanOrEqualTo(maxAmount).WithMessage(cp => $"{nameof(cp.Term)} must be less than 1000000000.");
        }
    }
}
