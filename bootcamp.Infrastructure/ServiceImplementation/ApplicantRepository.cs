using BCrypt.Net;
using bootcamp.Domain.Enums;
using bootcamp.Domain.IntefaceRepositories;
using bootcamp.Domain.Models;
using bootcamp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Infrastructure.ServiceImplementation
{
    public class ApplicantRepository : GenericRepository<Applicants>, IApplicantRepository
    {
        private readonly BootcampDbContext _context;
        public ApplicantRepository(BootcampDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Applicants> ApplicantCourseType(Guid applicantId, CourseType Course)
        {
            var applicant = await _context.Applicants.FindAsync(applicantId);
            if (applicant == null)
            {
                throw new Exception("No applicant found");
            }
            applicant.CourseType = Course;
            _context.SaveChanges();
            return applicant;
        }

        public async Task<Applicants> ApplicantLogin(Applicants applicants)
        {
            var user = await _context.Applicants.FirstOrDefaultAsync(x => x.Email == applicants.Email);
            if (user == null)
            {
                throw new Exception("Not a user");
            }
            var UserPassword = BCrypt.Net.BCrypt.Verify(applicants.PasswordHash, user.PasswordHash);
            if (!UserPassword)
            {
                throw new Exception("Incorrect password");
            }
            return user;
        }
    }
}
