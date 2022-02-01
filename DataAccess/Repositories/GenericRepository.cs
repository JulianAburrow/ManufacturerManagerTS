using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ManufacturerManagerTSContext _dbContext;
        
        public GenericRepository(ManufacturerManagerTSContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            //_dbContext.UserId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier));
            var hour = DateTime.Now.Hour;
            if (hour % 3 == 0)
            {
                _dbContext.UserId = 3;
                return;
            }
            if (hour % 2 == 0)
            {
                _dbContext.UserId = 2;
                return;
            }
            _dbContext.UserId = 1;
        }
            

        public async Task<IEnumerable<T>> GetAll() =>
            await _dbContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate) =>
            await _dbContext.Set<T>().Where(predicate).ToListAsync();

        public IQueryable<T> GetAllQueryable() =>
            _dbContext.Set<T>();

        public async Task<IEnumerable<T>> GetAllWithNavigationProperties() =>
            await _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(int id) =>
            await _dbContext.Set<T>().FindAsync(id);

        public async Task Add(T model) =>
            await _dbContext.AddAsync(model);

        public Task Update(T model)
        {
            try
            {
                _dbContext.Entry(model).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                var x = ex;
            }
            
            return _dbContext.SaveChangesAsync();
        }

        public Task Save() =>
            _dbContext.SaveChangesAsync();
    }
}
