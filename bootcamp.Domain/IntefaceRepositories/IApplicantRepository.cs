using bootcamp.Domain.Enums;
using bootcamp.Domain.Models;
using bootcamp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Domain.IntefaceRepositories
{
    public interface IApplicantRepository:IGenericRepository<Applicants>
    {
        Task<Applicants> ApplicantLogin(Applicants applicants);
        Task<Applicants> ApplicantCourseType(Guid applicantId, CourseType Course);
    }
}
