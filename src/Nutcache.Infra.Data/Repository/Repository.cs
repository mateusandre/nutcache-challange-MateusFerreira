using Microsoft.EntityFrameworkCore;
using Nutcache.Domain.Entities;

namespace Nutcache.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly NutcacheContext _context;

        public Repository(NutcacheContext context)
        {
            _context = context; 
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));
            
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var entity = await _context.Set<T>().FindAsync(new object[] { id, cancellationToken });

            if (entity is not null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new KeyNotFoundException(string.Format(ErrorMessagesResource.KeyNotFoundErrorMessage, id));
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            await CheckIfExistAsync(entity.Id, cancellationToken).ConfigureAwait(false);

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task CheckIfExistAsync(Guid id, CancellationToken cancellationToken)
        {
            bool exist = await _context.Set<T>().AnyAsync(x => x.Id == id, cancellationToken);
            if (!exist)
            {
                throw new KeyNotFoundException(string.Format(ErrorMessagesResource.KeyNotFoundErrorMessage, id));
            }
        } 
    }
}
