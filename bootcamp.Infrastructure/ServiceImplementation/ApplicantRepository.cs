using bootcamp.Domain.IntefaceRepositories;
using bootcamp.Domain.Models;
using bootcamp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Infrastructure.ServiceImplementation
{
    public class ApplicantRepository: GenericRepository<Applicants>, IApplicantRepository
    {
        public ApplicantRepository(BootcampDbContext context): base(context)
        {
            
        }
    }
}
