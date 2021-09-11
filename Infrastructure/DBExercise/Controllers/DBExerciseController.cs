using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Application.DBExercise.Messages.Commands;

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
        //[ProducesResponseType(typeof(Response<IEnumerable<ParkingSlotDto>>), 200)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
