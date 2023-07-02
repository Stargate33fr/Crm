namespace Crm.Api.Domain.Abstractions.Queries
{
    public interface IResponse<T>
    {
        T Contenu { get; set; }
    }
}
