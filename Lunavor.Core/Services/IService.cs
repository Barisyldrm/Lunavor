using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lunavor.Entities;

namespace Lunavor.Core.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(int id);
    }
} 