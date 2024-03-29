using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp.Domain.Repositories
{
    public interface IGenericRepository <T> where T: class
    {
        Task<T> GetById(Guid Id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}