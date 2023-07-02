using System.Data;

namespace Crm.Api.Services
{
    /// <summary>
    /// Représente une factory de connexion.
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Créer une connexion à la base de données.
        /// </summary>
        /// <returns>La connexion.</returns>
        IDbConnection Create();
    }
}
