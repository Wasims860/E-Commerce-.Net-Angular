using Core.Specifications;

namespace Core.Interfaces;
    public interface IGeniricRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync(); 
        Task<T> GetEntityWithSpec(ISpecifcations<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecifcations<T> spec); 

    }
