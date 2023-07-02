using System.Collections;

namespace Crm.Api.Domain.Abstractions.Queries
{
    public interface IResponseList<T> : IResponse<T>
        where T : IEnumerable
    {
        int Total { get; set; }
    }
}
