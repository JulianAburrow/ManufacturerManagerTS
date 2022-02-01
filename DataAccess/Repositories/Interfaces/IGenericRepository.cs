using ManufacturerManagerTS.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllWithNavigationProperties();

        IQueryable<T> GetAllQueryable();

        Task<T> GetById(int id);

        Task Add(T model);

        Task Update(T model);

        Task Save();
    }
}
