using Data.Core;
using Data.Repositories;
using Domain.Contracts;
using Domain.Core;

namespace Data.Implementation
{
    public class CitiesRepository : GenericRepository<Cities>, ICitiesRepository
    {
        public CitiesRepository(IContextUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}