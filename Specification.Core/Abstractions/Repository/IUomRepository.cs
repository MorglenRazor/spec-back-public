using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository
{
    public interface IUomRepository
    {
        Task<UnitOfMeasure> Get(int id);
    }
}
