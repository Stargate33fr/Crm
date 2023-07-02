using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    public abstract class AppControllerBase : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected AppControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
