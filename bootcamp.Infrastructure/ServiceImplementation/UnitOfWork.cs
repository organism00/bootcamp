using bootcamp.Domain.IntefaceRepositories;
using bootcamp.Domain.Repositories;
using bootcamp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Infrastructure.ServiceImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BootcampDbContext _context;
        private readonly IApplicantRepository _applicantRepository;
        public UnitOfWork(BootcampDbContext context, IApplicantRepository applicantRepository)
        {
            _context = context;
            _applicantRepository = applicantRepository;
        }

        public IApplicantRepository Applicants
        {
            get { return _applicantRepository; }
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_c.Dispose();
            }
        }
    }
}
