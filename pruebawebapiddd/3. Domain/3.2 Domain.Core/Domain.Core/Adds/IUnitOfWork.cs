using System;
namespace Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void BeginTransaction();
        void EndTransaction();
        void RollBack();
    }
}