using System;

namespace Crm.Api.Domain.Abstractions.Dtos
{
    public interface IEntiteSuiviModification : IEntiteSuiviCreation
    {
        string UpdatedBy { get; set; }
        DateTime? Updated { get; set; }
    }
}
