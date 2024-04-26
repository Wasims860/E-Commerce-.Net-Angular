using Core.Specifications;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGeniricRepository<T> where T : BaseEntity
{
    private readonly StoreContext _storeContext;
    public GenericRepository(StoreContext storeContext)
    {
        _storeContext = storeContext;
        
    }
    public async Task<T> GetByIdAsync(int id)
    {
       return await _storeContext.Set<T>().FindAsync(id);
    }

    public async Task<T> GetEntityWithSpec(ISpecifcations<T> spec)
    {
       return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _storeContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecifcations<T> spec)
    {
       return await ApplySpecification(spec).ToListAsync();
    
    }
    private IQueryable<T> ApplySpecification(ISpecifcations<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), spec);
    }
}
