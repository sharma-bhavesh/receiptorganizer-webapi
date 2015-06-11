using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using RentalReceiptOrganizer.Domain.Interface;
using RentalReceiptOrganizer.DomainService.Interface;

namespace RentalReceiptOrganizer.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbContext Context;
        protected DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            // add includes if any
            var query = DbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.AsExpandable().Where(predicate);
        }

        public T FindById(int id, params Expression<Func<T, object>>[] includes)
        {
            // add includes if any
            var query = DbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.AsExpandable().SingleOrDefault(o => o.Id == id);
        }

        public void Add(T newEntity)
        {
            DbSet.Add(newEntity);
        }

        public void Delete(object id)
        {
            T entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }


        public void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        /// <summary>
        /// TODO I am confused about this one, as to what if the entity is already attached??
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}