using Domain.Core;
using System;

namespace Domain.Contracts
{
    public interface ICitiesRepository : IGenericRepository<Cities>, IDisposable
    {
    }
}