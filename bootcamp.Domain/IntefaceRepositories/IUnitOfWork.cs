using bootcamp.Domain.IntefaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp.Domain.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IApplicantRepository Applicants { get; }

        int Save();
    }
}