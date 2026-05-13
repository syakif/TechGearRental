using TechGearRental.Domain.Common;

namespace TechGearRental.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
	Task<T?> GetByIdAsync(int id);
	Task<IReadOnlyList<T>> GetAllAsync();
	Task<T> AddAsync(T entity);
	void Update(T entity);
	void Delete(T entity);
}