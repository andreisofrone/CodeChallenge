using Application.DBExercise.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Infrastructure.DBExercise.Controllers
{
    [Route("api/v1/[controller]")]
    public class DBExerciseController
        : ControllerBase
    {
        private readonly IMediator _mediator;

        public DBExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("apply-for-credit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ApplyForCredit([FromBody] ApplyForCreditCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
