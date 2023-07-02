using Crm.Api.Queries.GeoLocalisation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [Route("geolocalisation")]
    public class GeoLocalisationController : AppControllerBase
    {
        public GeoLocalisationController(IMediator mediator)
            : base(mediator)
        { }

        [HttpPost]
        [Route("getLocalisations", Name = "Recherche localisations géographiques par motif")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IReadOnlyCollection<KeyValuePair<string, string>>>> GetLocalisations([FromBody] ObtenirElementsRechercheGeoQuery request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }
    }
}
