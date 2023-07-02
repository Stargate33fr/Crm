using AutoMapper;
using Crm.Api.Commands.Connexions;
using Crm.Api.Controllers;
using Crm.Api.Queries.Users;
using Crm.Api.ViewModel.Habilitations;
using Crm.Api.ViewModels.Habilitations;
using IDSoft.CrmWelcome.Api.Commands.FoyersFiscaux;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text;

namespace CrmApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [Route("user")]
    public class UserController : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="UserController"/>.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper">Le service de mapping d'objet.</param>
        public UserController(IMediator mediator,  IMapper mapper, ILogger<UserController> logger)
            : base(mediator)
        {
       
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// Return user.
        /// </summary>
        /// <returns>User</returns>
        /// <response code="200">User</response>
        [HttpGet]
        [Route("{mail}", Name = "GetUserByIdQuery")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserViewModel>> GetUserByIdQueryAsync([FromRoute] string mail, CancellationToken cancellationToken)
        {

            var request = new GetUserDetailQuery
            {
                Mail = mail
            };
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        /// Return user.
        /// </summary>
        /// <returns>User</returns>
        /// <response code="200">User</response>
        [HttpGet]
        [Route("usersLight", Name = "GetUsersSimplifiee")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<UserSimplifieeViewModel>>> GetUsersSimplifieeQueryAsync(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send( new GetUsersQuery(), cancellationToken));
        }


        [HttpPut]
        [Route("", Name = "UpdateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task UpdateUserAsync([FromBody] UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            await Mediator.Send(command, cancellationToken);
        }
    }
}