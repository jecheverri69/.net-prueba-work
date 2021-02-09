using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Core
{
    public interface IGenericRepository<T> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<T> GetExpression(Expression<Func<T, bool>> filter, string includeProperties = "", int numberOfObjectsPerPage = 0, int pageNumber = 0);
        IEnumerable<T> GetAll(string includeProperties = "", int numberOfObjectsPerPage = 0, int pageNumber = 0);
        T GetByID(object id);
        void Create(T entity);
        void Create(List<T> entity);
        void Delete(T entityToDelete);
        void Delete(ICollection<T> entityToDelete);
        void Update(T entityToUpdate);
        void Update(ICollection<T> entityToUpdate);
        T Map(T obj, T obj2);
    }
}