using Application.Common.Repositories.Contracts;
using Application.DBExercise.Dtos;
using Application.DBExercise.Messages.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.DBExercise.Handlers
{
    public  class ApplyForCreditCommandHandler
            : IRequestHandler<ApplyForCreditCommand, SolutionDto>
    {
        ITotalFutureDebtRepository TotalFutureDebtRepository { get; set; }

        IAppliedAmountRepository AppliedAmountRepository { get; set; }

        IUnitOfWork UnitOfWork { get; set; }

        IMapper Mapper { get; set; }

        public ApplyForCreditCommandHandler(ITotalFutureDebtRepository totalFutureDebtRepository, IAppliedAmountRepository appliedAmountRepository, IUnitOfWork unitOfWork, IMapper mapper ) 
        {
            TotalFutureDebtRepository = totalFutureDebtRepository ?? throw new ArgumentNullException(nameof(totalFutureDebtRepository));
            AppliedAmountRepository = appliedAmountRepository ?? throw new ArgumentNullException(nameof(appliedAmountRepository));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<SolutionDto> Handle(ApplyForCreditCommand request, CancellationToken cancellationToken)
        {

            var a = (await TotalFutureDebtRepository.GetAll()).ToList();

            return null; 
        }
    }
}
