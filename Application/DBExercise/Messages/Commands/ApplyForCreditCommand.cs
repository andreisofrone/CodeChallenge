using Application.DBExercise.Dtos;
using MediatR;

namespace Application.DBExercise.Messages.Commands
{
    public class ApplyForCreditCommand
        : IRequest<SolutionDto>
    {
        public long CreditAmount { get; set; }

        public long Term { get; set; }

        public long CurrentPreExistingCreditAmount { get; set; }
    }
}
