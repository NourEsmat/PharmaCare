using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaCare.Core.Interfaces;
using PharmaCare.infrastructure.Data;

namespace PharmaCare.infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDBContext _db;
        public GenericRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();   
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
           => await _db.Set<T>().AsNoTracking().ToListAsync();
        

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _db.Set<T>().AsQueryable();

            foreach(var item in includes)
            {
                query = query.Include(item);
            }
            
            return await query.ToListAsync();

        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db.Set<T>();
            foreach(var item in includes)
            {
                query = query.Include(item);
            }
            var entity = await query.FirstOrDefaultAsync(q => EF.Property<int>(q,"ID") == id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State= EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
