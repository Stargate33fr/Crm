using Crm.Api.Domain.Abstractions.Dtos.GeoLocalisation;
using Crm.Api.Domain.Abstractions.GeoLocalisation;
using Crm.Api.Domain.Constantes;
using Crm.Api.Infrastructure;
using Diacritics.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Crm.Api.Services.Implementation
{
    public class LocalisationService : ILocalisationService
    {
        private readonly CrmDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;

        public LocalisationService(CrmDbContext context, IMemoryCache memoryCache, ILoggerFactory loggerFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _memoryCache = memoryCache;
            _logger = loggerFactory.CreateLogger(typeof(LocalisationService));

        }

        public async Task<IReadOnlyCollection<KeyValuePair<string, string>>> GetLocalisationsAsync(string? pattern, CancellationToken cancellationToken)
        {
            if (!_memoryCache.TryGetValue(Constantes.ConstantesCacheApplicatif.CACHE_KEY_RECHERCHE_LOCALISATION, out List<IElementRechercheGeo>? elementsRechercheGeo))
            {
                elementsRechercheGeo = new List<IElementRechercheGeo>();

                var villes = await ObtenirToutesVillesAvecCodePostalPourRechercheAsync(cancellationToken);
                if (villes != null)
                {
                    elementsRechercheGeo.AddRange(villes);
                }
               
                var departments = await ObtenirTousDepartmentsPourRechercheAsync(cancellationToken);
                if (departments != null)
                {
                    elementsRechercheGeo.AddRange(departments);
                }
                var regions = await ObtenirToutesRegionsPourRechercheAsync(cancellationToken);
                if (regions != null)
                {
                    elementsRechercheGeo.AddRange(regions);
                }

                _memoryCache.Set(Constantes.ConstantesCacheApplicatif.CACHE_KEY_RECHERCHE_LOCALISATION, elementsRechercheGeo);
            }

            // cas d'une multi sélection : on ne cherche que sur le dernier "morceau"
            // le séparateur est le ;
            pattern = ConvertirChaineSansAccent(pattern);
            pattern = pattern?.ToLower().Trim();

            if (pattern != null && pattern.Contains(';'))
            {
                pattern = pattern.Split(';')
                    .LastOrDefault()
                    .RemoveDiacritics()
                    .Replace("-", " ")
                    .Trim();
            }
                

            IReadOnlyCollection<KeyValuePair<string, string>>? liste = null;
          
            // Recherche sur code postal / ville à partir de 3 caractères.
            if (pattern != null && pattern.Length >= 2)
            {
                liste = elementsRechercheGeo.Where(elg => !string.IsNullOrEmpty(elg.SearchForLocalisation) && ConvertirChaineSansAccent(elg.SearchForLocalisation).StartsWith(pattern))
                    .Union(elementsRechercheGeo.Where(elg => !string.IsNullOrEmpty(elg.SearchForCodePostal) && ConvertirChaineSansAccent(elg.SearchForCodePostal).StartsWith(pattern)))
                    .Union(elementsRechercheGeo.Where(elg => !string.IsNullOrEmpty(elg.SearchForVille) && ConvertirChaineSansAccent(elg.SearchForVille).StartsWith(pattern)))
                    .Take(100)
                    .ToDictionary(elg => elg.ValueForLocalisation, elg => elg.TextForLocalisation).ToList();
            }
            return liste;
        }

        private string? ConvertirChaineSansAccent(string? texte)
        {
            if ((texte != null) && (texte != string.Empty))
            {
                char[] oldChar = { 'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', 'à', 'á', 'â', 'ã', 'ä', 'å', 'Ò', 'Ó', 'Ô', 'Õ', 'Ö', 'Ø', 'ò', 'ó', 'ô', 'õ', 'ö', 'ø', 'È', 'É', 'Ê', 'Ë', 'è', 'é', 'ê', 'ë', 'Ì', 'Í', 'Î', 'Ï', 'ì', 'í', 'î', 'ï', 'Ù', 'Ú', 'Û', 'Ü', 'ù', 'ú', 'û', 'ü', 'ÿ', 'Ñ', 'ñ', 'Ç', 'ç', '°' };
                char[] newChar = { 'A', 'A', 'A', 'A', 'A', 'A', 'a', 'a', 'a', 'a', 'a', 'a', 'O', 'O', 'O', 'O', 'O', 'O', 'o', 'o', 'o', 'o', 'o', 'o', 'E', 'E', 'E', 'E', 'e', 'e', 'e', 'e', 'I', 'I', 'I', 'I', 'i', 'i', 'i', 'i', 'U', 'U', 'U', 'U', 'u', 'u', 'u', 'u', 'y', 'N', 'n', 'C', 'c', ' ' };
                int i = 0;

                foreach (char monc in oldChar)
                {
                    texte = texte.Replace(monc, newChar[i]);
                    i++;
                }
            }
            if (texte != null)
            {
                return texte;
            }
            return null;
        }

        public async Task<IReadOnlyCollection<IElementRechercheGeo>?> ObtenirToutesVillesAvecCodePostalPourRechercheAsync(CancellationToken cancellationToken)
        {
            if (_context != null && _context.City != null)
            {
                var listeCodepostauxVille = await _context.City.ToListAsync();

                return listeCodepostauxVille.OrderBy(cpv => cpv.PostalCode).ThenBy(cpv => cpv.Name).Select(cpv => new ElementRechercheGeo
                {
                    TextForLocalisation = $"{cpv.PostalCode} - {cpv.Name}",
                    ValueForLocalisation = $"V-{cpv.Id}${cpv.PostalCode}-{cpv.Name}",
                    SearchForLocalisation = cpv.Name.ToLower().RemoveDiacritics().Replace("-", " "),
                    SearchForCodePostal = cpv.PostalCode.ToLower(),
                    SearchForVille = cpv.Name.ToLower()
                }).ToList();
            }
            else
            {
                return null;
            }
        }

        public async Task<IReadOnlyCollection<IElementRechercheGeo>?> ObtenirTousDepartmentsPourRechercheAsync(CancellationToken cancellationToken)
        {
            if (_context != null && _context.Department != null)
            {
                var listeDepartements = await _context.Department.ToListAsync();

                return listeDepartements.Select(d => new ElementRechercheGeo
                {
                    TextForLocalisation = $"{d.Name} - {d.Code}",
                    ValueForLocalisation = $"D-{d.Id}${d.Name}-{d.Code}",
                    SearchForLocalisation = d.Name.ToLower().RemoveDiacritics().Replace("-", " "),
                    SearchForCodePostal = d.Code.ToLower(),
                    SearchForVille = null
                }).ToList();
            }
            else
            {
                return null;
            }
        }


        public async Task<IReadOnlyCollection<IElementRechercheGeo>?> ObtenirToutesRegionsPourRechercheAsync(CancellationToken cancellationToken)
        {
            if (_context != null && _context.Region != null)
            {
                var listeRegions = await _context.Region.ToListAsync();

                return listeRegions.Select(r => new ElementRechercheGeo
                {
                    TextForLocalisation = $"{r.Name}",
                    ValueForLocalisation = $"R-{r.Id}${r.Name}",
                    SearchForLocalisation = r.Name.RemoveDiacritics().Replace("-", " "),
                    SearchForCodePostal = null,
                    SearchForVille = null
                }).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
