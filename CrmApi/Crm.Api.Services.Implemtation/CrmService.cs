using Crm.Api.Domain.Search;
using Crm.Api.Infrastructure;
using Crm.Api.Infrastructure.Entities;
using Crm.Api.Infrastructure.Helpers;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Crm.Api.Services.Implementation
{
    public class CrmService : ICrmService
    {
        private readonly CrmDbContext _context;

        public CrmService(CrmDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserEntity?> ObtientParIdentifiantEtMotDePasseAsync(string mail, string password, CancellationToken cancellationToken)
        {
            if (_context != null && _context.User != null)
            {
                return await _context.User.FirstOrDefaultAsync(v => v.Mail == mail && v.Password == password.ChiffrerChaine(), cancellationToken: cancellationToken);
            }
            return null;
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (_context != null && _context.User != null)
            {
                return await _context.User.FirstOrDefaultAsync(v => v.Id == id, cancellationToken: cancellationToken);
            }
            return null;
        }


        public async Task<List<UserEntity>?> GetUsersAsync(CancellationToken cancellationToken)
        {
            if (_context != null && _context.User != null)
            {
                return await _context.User.ToListAsync(cancellationToken);
            }
            return null;
        }

        public async Task<ContactEntity?> GetContactByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (_context != null && _context.Contact != null)
            {
                return await _context.Contact
                    .Include(v => v.Address)
                        .ThenInclude(v => v.City)
                        .ThenInclude(v => v.Department)
                        .ThenInclude(v => v.Region)
                        .ThenInclude(v => v.Country)
                    .FirstOrDefaultAsync(v => v.Id == id, cancellationToken: cancellationToken);
            }
            return null;
        }

        public async Task<List<CivilityEntity>> GetCivilities(CancellationToken cancellationToken)
        {
            if (_context != null && _context.Civility != null)
            {
                return await _context.Civility.ToListAsync(cancellationToken);
            }
            return null;
        }

        public async Task<UserEntity?> GetByEmailAsync(string mail, CancellationToken cancellationToken)
        {
            if (_context != null && _context.User != null)
            {
                return await _context.User
                    .Include(v => v.Address)
                        .ThenInclude(v => v.City)
                        .ThenInclude(v => v.Department)
                        .ThenInclude(v => v.Region)
                        .ThenInclude(v => v.Country)
                    .Include(v => v.Civility)
                    .FirstOrDefaultAsync(v => v.Mail == mail, cancellationToken: cancellationToken);
            }
            return null;
        }

        public async Task<List<ContactEntity>?> GetContacts(string? mail, string? firstName, string? lastName, int? conseillerId, Pagination pagination, Tri tri, CancellationToken cancellationToken)
        {
            if (_context != null && _context.Contact != null)
            {
                if (!string.IsNullOrEmpty(mail) || !string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName) || conseillerId != null)
                {
                    string ascdesc = tri.Ascendant ? "ASC" : "DESC";
                    var triage = $"{tri.Champ} {ascdesc}";
                    return await _context.Contact
                        .Include(v => v.Address)
                         .ThenInclude(v => v.City)
                            .ThenInclude(v => v.Department)
                            .ThenInclude(v => v.Region)
                            .ThenInclude(v => v.Country)
                        .Include(v => v.Conseiller)
                        .Where(u => (string.IsNullOrEmpty(mail) || u.Mail == mail)
                                                            && (string.IsNullOrEmpty(firstName) || u.FirstName == firstName)
                                                            && (string.IsNullOrEmpty(lastName) || u.LastName == lastName)
                                                            && (conseillerId == null || u.ConseillerId == conseillerId))
                                                            .OrderBy(triage)
                                                            .Skip(pagination.Skip)
                                                            .Take(pagination.Limite).ToListAsync();
                }
                else
                {
                    if (tri != null)
                    {
                        string ascdesc = tri.Ascendant ? "ASC" : "DESC";
                        var triage = $"{tri.Champ} {ascdesc}";
                        return await _context.Contact
                            .Include(v => v.Address)
                             .ThenInclude(v => v.City)
                                .ThenInclude(v => v.Department)
                                .ThenInclude(v => v.Region)
                                .ThenInclude(v => v.Country)
                            .Include(v => v.Conseiller)
                           .OrderBy(triage)
                            .Skip(pagination.Skip)
                            .Take(pagination.Limite).ToListAsync();
                    }
                }
            }
            return null;
        }

        public async Task<int> GetContactsNumber(string? mail, string? firstName, string? lastName, int? conseillerId, CancellationToken cancellationToken)
        {
            if (_context != null && _context.Contact != null)
                if (!string.IsNullOrEmpty(mail) || !string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName) || conseillerId != null)
            {
               var contacts =  await _context.Contact
                    .Include(v => v.Address)
                     .ThenInclude(v => v.City)
                        .ThenInclude(v => v.Department)
                        .ThenInclude(v => v.Region)
                        .ThenInclude(v => v.Country)
                    .Include(v => v.Conseiller)
                    .Where(u => (string.IsNullOrEmpty(mail) || u.Mail == mail)
                                                        && (string.IsNullOrEmpty(firstName) || u.FirstName == firstName)
                                                        && (string.IsNullOrEmpty(lastName) || u.LastName == lastName)
                                                        && (conseillerId == null || u.ConseillerId == conseillerId)).ToListAsync();

                    return contacts.Count;
                }
                else
                {
                    var contacts = await _context.Contact
                   .Include(v => v.Address)
                    .ThenInclude(v => v.City)
                       .ThenInclude(v => v.Department)
                       .ThenInclude(v => v.Region)
                       .ThenInclude(v => v.Country)
                   .Include(v => v.Conseiller)
                   .ToListAsync();

                    return contacts.Count;
                }
            return 0;
        }

        public async Task UpdateUser(UserEntity user, CancellationToken cancellationToken)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> AddUser(UserEntity user, CancellationToken cancellationToken)
        {
            var inserted = await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return inserted.Entity;
        }

        public async Task UpdateContact(ContactEntity contact, CancellationToken cancellationToken)
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<ContactEntity> AddContact(ContactEntity contact, CancellationToken cancellationToken)
        {
            var inserted = await _context.AddAsync(contact);
            await _context.SaveChangesAsync();

            return inserted.Entity;
        }

        public async Task<ValidationFailure> VerifieExistenceEtTypeAsync(string nomPropriete, int id, Type type, CancellationToken cancellationToken)
        {
            if (_context !=null && _context.City != null)
            {
                var valeur = await _context.City.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                if (valeur == null || valeur.GetType() != type)
                {
                    return new ValidationFailure(nomPropriete, $"L'élément de type {type.Name} avec l'id {id} n'existe pas dans le référentiel");
                }
            }

            return null;
        }
    }
}
