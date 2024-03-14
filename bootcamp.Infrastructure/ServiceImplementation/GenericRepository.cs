using bootcamp.Domain.Repositories;
using bootcamp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Infrastructure.ServiceImplementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BootcampDbContext _context;
        public GenericRepository(BootcampDbContext context)
        {
            _context = context;       
        }
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void  Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
