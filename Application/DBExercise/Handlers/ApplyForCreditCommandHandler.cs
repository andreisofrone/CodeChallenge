using Application.DBExercise.AggregateService;
using Application.DBExercise.Dtos;
using Application.DBExercise.Messages.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DBExercise.Handlers
{
    public  class ApplyForCreditCommandHandler
            : IRequestHandler<ApplyForCreditCommand, SolutionDto>
    {
        //IApplyForCreditAggregateService AggregateService { get; }

        public ApplyForCreditCommandHandler() { }
              //=> AggregateService = aggregateService ?? throw new ArgumentNullException(nameof(aggregateService));


        public async Task<SolutionDto> Handle(ApplyForCreditCommand request, CancellationToken cancellationToken)
        {
            //var slot = _mapper.Map<ParkingSlot>(request);
            //await _slotRepository.AddAsync(slot);
            //await _unitOfWork.CompleteAsync();

            //return slot;

            return null; 
        }
    }
}
