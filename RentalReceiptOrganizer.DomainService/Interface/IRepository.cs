using System;
using System.Linq;
using System.Linq.Expressions;

namespace RentalReceiptOrganizer.DomainService.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        T FindById(int id, params Expression<Func<T, object>>[] includes);

        void Add(T newEntity);

        void Delete(T entity);
    }
}