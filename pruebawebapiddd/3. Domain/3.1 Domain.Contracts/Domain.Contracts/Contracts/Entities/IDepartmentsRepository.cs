using Domain.Core;
using System;

namespace Domain.Contracts
{
    public interface IDepartmentsRepository : IGenericRepository<Departments>, IDisposable
    {
    }
}