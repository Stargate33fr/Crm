using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IDSoft.CrmWelcome.Domain.Abstractions.Services
{
    public interface IVerifieurReferencesService
    {
        Task<List<ValidationFailure>> VerifieAsync(params Func<Task<ValidationFailure>>[] verifieursAsync);
        Task<ValidationFailure> VerifieExistenceCityAsync(int id, CancellationToken cancellationToken);
    }
}
