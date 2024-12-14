using ControllerCqrs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Models;
using Template.Services.Query.ClientQuery;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/client")]
    public class ClientController : ServiceBaseController
    {
        public ClientController(IMediator mediator) : base(mediator) { }

        ///<summary>
        ///Listado Clientes
        ///</summary>
        [HttpGet("list")]
        public Task<ActionResult<IEnumerable<ClientModel>>> ListClient() => SendRequest(new ListClientQuery());

        ///<summary>
        ///Obtener Cliente
        ///</summary>
        [HttpGet("{id}")]
        public Task<ActionResult<ClientModel>> GetClient(Guid id) => SendRequest(new GetClientQuery(id));
    }
}