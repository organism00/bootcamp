using bootcamp.Domain.Enums;
using bootcamp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Application.Interface
{
    public interface IApplicantService
    {
        Task<Applicants> CreateUser(Applicants applicants);
        Task<List<Applicants>> GetAllApplicants();
        Task<Applicants> GetApplicantById(Guid Id);
        Task UpdateApplicant(Applicants applicants);
        Task DeleteApplicant(Guid Id);
        Task<Applicants> ApplicantLogin(Applicants applicants);
        Task<Applicants> ApplicantCourseType(Guid applicantId, CourseType Course);
    }
}
