using ControllerCqrs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Command.RequestChangeCommand;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/request-change")]
    public class RequestChangeController : ServiceBaseController
    {
        public RequestChangeController(IMediator mediator) : base(mediator) { }

        ///<summary>
        ///Cambio de fecha consulta medica
        ///</summary>
        [HttpPost()]
        public Task<ActionResult<bool>> StoreAccout([FromBody] ModifiedRequestChangeCommand command) => SendRequest(command);

    }
}