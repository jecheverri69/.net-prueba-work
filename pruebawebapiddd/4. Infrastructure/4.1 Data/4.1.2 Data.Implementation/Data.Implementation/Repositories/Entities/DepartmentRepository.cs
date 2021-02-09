using Data.Core;
using Data.Repositories;
using Domain.Contracts;
using Domain.Core;

namespace Data.Implementation
{
    public class DepartmentsRepository : GenericRepository<Departments>, IDepartmentsRepository
    {
        public DepartmentsRepository(IContextUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}