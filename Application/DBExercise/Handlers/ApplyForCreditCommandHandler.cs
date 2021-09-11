using Application.Common.Repositories.Contracts;
using Application.DBExercise.Dtos;
using Application.DBExercise.Messages.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Common.Extensions;

namespace Application.DBExercise.Handlers
{
    public  class ApplyForCreditCommandHandler
            : IRequestHandler<ApplyForCreditCommand, SolutionDto>
    {
        ITotalFutureDebtRepository TotalFutureDebtRepository { get; set; }

        IAppliedAmountRepository AppliedAmountRepository { get; set; }

        IMapper Mapper { get; set; }

        public ApplyForCreditCommandHandler(ITotalFutureDebtRepository totalFutureDebtRepository, IAppliedAmountRepository appliedAmountRepository, IMapper mapper ) 
        {
            TotalFutureDebtRepository = totalFutureDebtRepository ?? throw new ArgumentNullException(nameof(totalFutureDebtRepository));
            AppliedAmountRepository = appliedAmountRepository ?? throw new ArgumentNullException(nameof(appliedAmountRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SolutionDto> Handle(ApplyForCreditCommand request, CancellationToken cancellationToken)
        {
            var result = new SolutionDto();
            var totalFutureDebts = (await TotalFutureDebtRepository.GetAll()).ToList();
            var appliedAmounts = (await AppliedAmountRepository.GetAll()).ToList();

            var decision = appliedAmounts.First(am => request.CreditAmount >= am.LowerBound && request.CreditAmount < am.UpperBound).Decision;
            var totalFutureDebt = request.CreditAmount + request.CurrentPreExistingCreditAmount;
            var interestRate = totalFutureDebts.First(am => totalFutureDebt >= am.LowerBound && totalFutureDebt < am.UpperBound).InterestRate;

            return new SolutionDto() { Decision = decision.ToYesNoString(), InterestRate = interestRate }; 
        }
    }
}
