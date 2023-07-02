using Crm.Api.Domain.Search;
using Crm.Api.Infrastructure.Entities;
using FluentValidation.Results;

namespace Crm.Api.Services
{
    public interface ICrmService
    {
        Task<ValidationFailure> VerifieExistenceEtTypeAsync(string nomPropriete, int id, Type type, CancellationToken cancellationToken);
        Task<UserEntity?> ObtientParIdentifiantEtMotDePasseAsync(string mail, string password, CancellationToken cancellationToken);
        Task<UserEntity?> GetByEmailAsync(string mail, CancellationToken cancellationToken);
        Task<List<CivilityEntity>> GetCivilities(CancellationToken cancellationToken);
        Task<List<ContactEntity>?> GetContacts(string? mail, string? FirstName, string? LastName , int? ConseillerId, Pagination pagination, Tri tri, CancellationToken cancellationToken);
        Task<int> GetContactsNumber(string? mail, string? firstName, string? lastName, int? conseillerId, CancellationToken cancellationToken);
        Task UpdateUser(UserEntity user, CancellationToken cancellationToken);
        Task UpdateContact(ContactEntity contact, CancellationToken cancellationToken);
        Task<UserEntity?> GetUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<ContactEntity?> GetContactByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<UserEntity>?> GetUsersAsync(CancellationToken cancellationToken);
    }
}