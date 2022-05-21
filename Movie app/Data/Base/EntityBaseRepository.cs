using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbConetext _Context;
        public EntityBaseRepository(AppDbConetext Context)
        {
            _Context = Context;
        }
        public async Task AddAsync(T entity) { await _Context.Set<T>().AddAsync(entity); await _Context.SaveChangesAsync(); }

        public async Task DeleteAsync(int Id)
        {
            var entity = await _Context.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);
            EntityEntry entry = _Context.Entry<T>(entity);
            entry.State = EntityState.Deleted;
            await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()=> await _Context.Set<T>().ToListAsync();

        public async Task<T> GetIdAsync(int Id)=> await _Context.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);

        public async Task UpdateAsync(int Id, T entity)
        {
            EntityEntry entry = _Context.Entry<T>(entity);
            entry.State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
}
