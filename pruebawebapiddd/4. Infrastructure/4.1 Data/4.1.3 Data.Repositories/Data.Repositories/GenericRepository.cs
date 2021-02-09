using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Data.Core;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly IContextUnitOfWork _UnitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get { return _UnitOfWork; }
        }

        public GenericRepository(IContextUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void Create(T entity)
        {
            _UnitOfWork.Set<T>().Add(entity);
        }

        public void Create(List<T> entity)
        {
            _UnitOfWork.Set<T>().AddRange(entity);
        }

        public void Delete(T entityToDelete)
        {
            if (_UnitOfWork.State<T>(entityToDelete) == EntityState.Detached)
            {
                _UnitOfWork.Set<T>().Attach(entityToDelete);
            }
            _UnitOfWork.Set<T>().Remove(entityToDelete);
        }

        public void Delete(ICollection<T> entityToDelete)
        {
            _UnitOfWork.Set<T>().RemoveRange(entityToDelete);
        }

        public IEnumerable<T> GetAll(string includeProperties = "", int numberOfObjectsPerPage = 0, int pageNumber = 0)
        {
            IQueryable<T> query;

            if (numberOfObjectsPerPage > 0)
            {
                query = _UnitOfWork.Set<T>().Skip(numberOfObjectsPerPage * pageNumber)
                    .Take(numberOfObjectsPerPage);
            }
            else
            {
                query = _UnitOfWork.Set<T>();
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public T GetByID(object id)
        {
            return _UnitOfWork.Set<T>().Find(id);
        }

        public IEnumerable<T> GetExpression(Expression<Func<T, bool>> filter, string includeProperties = "", int numberOfObjectsPerPage = 0, int pageNumber = 0)
        {
            IQueryable<T> query;

            if (numberOfObjectsPerPage > 0)
            {
                query = _UnitOfWork.Set<T>().Where(filter).Skip(numberOfObjectsPerPage * pageNumber)
                    .Take(numberOfObjectsPerPage);
            }
            else
            {
                query = _UnitOfWork.Set<T>().Where(filter);
            }


            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }


        public void Update(T entityToUpdate)
        {
            _UnitOfWork.Set<T>().Attach(entityToUpdate);
            _UnitOfWork.SetModified<T>(entityToUpdate);
        }

        public void Update(ICollection<T> entityToUpdate)
        {
            _UnitOfWork.Set<T>().AttachRange(entityToUpdate);
            foreach (T entity in entityToUpdate)
            {
                _UnitOfWork.SetModified<T>(entity);
            }
        }

        public T Map(T obj, T obj2)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo p in properties)
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(p.Name);
                var value = p.GetValue(obj);
                propertyInfo.SetValue(obj2, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
            return obj2;
        }

        public void Dispose()
        {
            _UnitOfWork.Dispose();
        }
    }
}