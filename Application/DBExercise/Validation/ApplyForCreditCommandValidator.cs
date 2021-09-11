using Application.DBExercise.Messages.Commands;
using FluentValidation;

namespace Application.DBExercise.Validation
{
    public class ApplyForCreditCommandValidator
     : AbstractValidator<ApplyForCreditCommand>
    {
        public ApplyForCreditCommandValidator()
        {
            RuleFor(cp => cp.CreditAmount)
                    .NotEmpty()
                    .WithMessage(cp => $"{nameof(cp.CreditAmount)} is required.");

            RuleFor(cp => cp.CurrentCreditAmount)
                   .NotEmpty()
                   .WithMessage(cp => $"{nameof(cp.CurrentCreditAmount)} is required.");

            RuleFor(cp => cp.Term)
                   .NotEmpty()
                   .WithMessage(cp => $"{nameof(cp.Term)} is required.");
        }
    }
}
