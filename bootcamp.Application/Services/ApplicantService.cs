using bootcamp.Application.Interface;
using bootcamp.Domain.Enums;
using bootcamp.Domain.Models;
using bootcamp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Application.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Applicants> ApplicantCourseType(Guid applicantId, CourseType Course)
        {
            var res= await _unitOfWork.Applicants.ApplicantCourseType(applicantId, Course);
            _unitOfWork.Save();
            return res;
        }

        public async Task<Applicants> ApplicantLogin(Applicants applicants)
        {
            var applicant  = await _unitOfWork.Applicants.ApplicantLogin(applicants);
            return applicant;
        }

        public async Task<Applicants> CreateUser(Applicants applicants)
        {
            var addUser = await _unitOfWork.Applicants.Add(applicants);
            _unitOfWork.Save();
            return addUser;
        }

        public async Task DeleteApplicant(Guid Id)
        {
            var user = await _unitOfWork.Applicants.GetById(Id);
            if (user != null)
            {
                _unitOfWork.Applicants.Delete(user);
                _unitOfWork.Save();

            }
        }

        public async Task<List<Applicants>> GetAllApplicants()
        {
            var user = await _unitOfWork.Applicants.GetAll();
            return user;
        }

        public async Task<Applicants> GetApplicantById(Guid Id)
        {
            var user = await _unitOfWork.Applicants.GetById(Id);
            return user;
        }

        public async Task UpdateApplicant(Applicants applicants)
        {
            var request = await _unitOfWork.Applicants.GetById(applicants.ApplicantId);
            if (request != null)
            {
                request.Firstname = applicants.Firstname;
                request.Lastname = applicants.Lastname;
                request.Email = applicants.Email;
                request.Phone = applicants.Phone;
                _unitOfWork.Applicants.Update(request);
                var result = _unitOfWork.Save();

            }
        }
    }
}
