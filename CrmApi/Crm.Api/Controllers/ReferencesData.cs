using AutoMapper;
using Crm.Api.Queries.Utilisateurs;
using Crm.Api.ViewModel.Habilitations;
using Crm.Api.ViewModels.Habilitations;
using CrmApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [Route("referenceData")]
    public class ReferencesData : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="UserController"/>.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper">Le service de mapping d'objet.</param>
        public ReferencesData(IMediator mediator, IMapper mapper, ILogger<UserController> logger)
            : base(mediator)
        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// list of civilites.
        /// </summary>
        /// <returns>list of civilites.</returns>
        /// <response code="200">return civilites.</response>
        [HttpGet]
        [Route("civilities", Name = "GetCivilitesQuery")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IReadOnlyCollection<CivilityViewModel>>> GetCivilitesQueryAsync(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCivilitiesQuery(), cancellationToken));
        }
    }
}
