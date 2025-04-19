using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Service.PersistenceDb;
using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;

namespace Infrastructure.PersistenceDb
{
    public class GenericRepository<T, TKey>(AppDbContext context) : IGenericRepository<T, TKey>  where T : class, IEntity<TKey>
    {
        private readonly AppDbContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
        {
            return asNoTracking
                ? await _dbSet.AsNoTracking().ToListAsync()
                : await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity ?? throw new KeyNotFoundException($"Entity with id {id} was not found.");
        }

        public async Task AddAsync(T entity, bool saveChanges = true)
        {
            await _dbSet.AddAsync(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, bool saveChanges = true)
        {
            var existing = await _dbSet.FindAsync(entity.Id);

            if (existing == null)
                throw new KeyNotFoundException("Entity not found.");

            _context.Entry(existing).CurrentValues.SetValues(entity);

            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id, bool saveChanges = true)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with id {id} was not found.");

            _dbSet.Remove(entity);

            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            var query = _dbSet.Where(predicate);
            return asNoTracking
                ? await query.AsNoTracking().ToListAsync()
                : await query.ToListAsync();
        }
    }
}
