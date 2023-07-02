using AutoMapper;
using Crm.Api.Queries.Contacts;
using Crm.Api.Queries.Utilisateurs;
using Crm.Api.ViewModels.Habilitations;
using CrmApi.Controllers;
using IDSoft.CrmWelcome.Api.Commands.FoyersFiscaux;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [Route("contacts")]
    public class ContactController : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="ContactController"/>.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper">Le service de mapping d'objet.</param>
        public ContactController(IMediator mediator, IMapper mapper, ILogger<UserController> logger)
            : base(mediator)
        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// Retourne l'ensemble des départements.
        /// </summary>
        /// <returns>La liste des départements.</returns>
        /// <response code="200">Retourne la liste des départements.</response>
        [HttpPost]
        [Route("search", Name = "SearchContact")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ListeContactsResponse>> SearchContactAsync([FromBody] GetContactDetailQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPut]
        [Route("", Name = "updateContact")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task UpdateContactAsync([FromBody] UpdateContactCommand command, CancellationToken cancellationToken = default)
        {
            await Mediator.Send(command, cancellationToken);
        }

    }
}
