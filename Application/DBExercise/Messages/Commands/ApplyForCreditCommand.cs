using Application.DBExercise.Dtos;
using MediatR;

namespace Application.DBExercise.Messages.Commands
{
    public class ApplyForCreditCommand
        : IRequest<SolutionDto>
    {
        public int CreditAmount { get; set; }

        public int Term { get; set; }

        public int CurrentCreditAmount { get; set; }
    }
}
