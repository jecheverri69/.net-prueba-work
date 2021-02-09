
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Domain.Core;

namespace Data.Core
{
    public class WorkUniversityContext : DbContext, IContextUnitOfWork
    {
        private IDbContextTransaction Transaction;

        public WorkUniversityContext(DbContextOptions<WorkUniversityContext> options)
            : base(options)
        {
        }

        DbSet<Departments> _Departments;
        public DbSet<Departments> Departments
        {
            get
            {
                return _Departments ?? (_Departments = base.Set<Departments>());
            }
        }


        private DbSet<Cities> _Cities;
        public DbSet<Cities> Cities
        {
            get
            {
                return _Cities ?? (_Cities = base.Set<Cities>());
            }
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SetModified<T>(T item) where T : class
        {
            Entry(item).State = EntityState.Modified;
        }

        public EntityState State<T>(T item) where T : class
        {
            return Entry(item).State;
        }
        public void Save()
        {
            base.SaveChanges();
            
        }

        public virtual void BeginTransaction()
        {
            Transaction = base.Database.BeginTransaction();
        }

        public virtual void EndTransaction()
        {
            Transaction.Commit();
        }

        public virtual void RollBack()
        {
            Transaction.Rollback();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }
    }
}