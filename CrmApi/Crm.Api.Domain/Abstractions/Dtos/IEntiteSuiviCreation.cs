using System;

namespace Crm.Api.Domain.Abstractions.Dtos
{
    public interface IEntiteSuiviCreation
    {
        string CreatedBy { get; set; }
        DateTime? Created { get; set; }
    }
}
