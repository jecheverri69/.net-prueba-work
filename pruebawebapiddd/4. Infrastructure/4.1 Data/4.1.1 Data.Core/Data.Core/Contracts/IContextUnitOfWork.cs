using System;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Data.Core
{
    public interface IContextUnitOfWork : IUnitOfWork, IDisposable
    {

        DbSet<Cities> Cities { get; }
        
        DbSet<Departments> Departments { get; }


        DbSet<T> Set<T>() where T : class;

        EntityState State<T>(T item) where T : class;

        void SetModified<T>(T item) where T : class;
    }
}