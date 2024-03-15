using bootcamp.Api.DTO;
using bootcamp.Api.DTO.ApplicantDTO;
using bootcamp.Api.Response;
using bootcamp.Application.Interface;
using bootcamp.Application.Services;
using bootcamp.Domain.Models;
using bootcamp.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _service;
        private readonly ILogger<ApplicantController> _logger;
        private readonly IConfiguration _configuration;
        private readonly BootcampDbContext _context;
        public ApplicantController(IApplicantService service, ILogger<ApplicantController> logger, IConfiguration configuration,
            BootcampDbContext context)
        {
            _service = service;
            _logger = logger;
            _configuration = configuration;
            _context = context;

        }

        [HttpPost]
        [Route("UserApplication")]
        public async Task<ActionResult<DefaultResponse<string>>> UserApplication([FromBody] PostApplication application)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(application.Password);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DefaultResponse<string> response = new();

            var checkApplicant = _context.Applicants.FirstOrDefault(x => x.Email == application.Email);
            if (checkApplicant != null)
            {
                response.ResponseMessage = "Applicant Account already exist";
                response.ResponseCode = "55";
                response.Status = false;
                return BadRequest(response);
            }

            try
            {
                var applicant = new Applicants
                {
                    Firstname = application.Firstname,
                    Lastname = application.Lastname,
                    Email = application.Email,
                    Phone = application.Phone,
                    Username = application.Username,
                    PasswordHash = passwordHash,
                };

                var request = await _service.CreateUser(applicant);
                response.Status = true;
                response.ResponseCode = "00";
                response.ResponseMessage = "Applicant Account Created Successfully";

                return Ok(applicant);
            }
            catch (Exception ex)
            {
                _logger.LogError("Applicant account creation failed", ex);
                response.Status = false;
                response.ResponseCode = "99";
                response.ResponseMessage = "An Error Occured";
                return StatusCode(500, response);
            }
        }


        [HttpGet]
        [Route("GetAllApplicant")]
        [Authorize]
        public async Task<ActionResult<DefaultResponse<List<Applicants>>>> GetAllApplicant()
        {

            DefaultResponse<List<Applicants>> response = new();
            try
            {
                var request = await _service.GetAllApplicants();
                response.Status = request.Count > 0;
                response.Data = request;
                response.ResponseCode = "00";
                response.ResponseMessage = request.Count > 0 ? "Applicanta found" : "Applicant not found";

                return Ok(request);

            }
            catch (Exception ex)
            {
                _logger.LogError("Fail attempt getting applicanta", ex);
                response.Status = false;
                response.ResponseCode = "99";
                response.ResponseMessage = "An Error Occured";
                return StatusCode(500, response);
            }

        }

        [HttpGet]
        [Route("GetApplicantById/{Id}")]
        [Authorize]
        public async Task<ActionResult<DefaultResponse<Applicants>>> GetApplicantById(Guid Id)
        {
            DefaultResponse<Applicants> response = new();
            try
            {
                var getApplicant = await _service.GetApplicantById(Id);
                if (getApplicant == null)
                {
                    response.Status = false;
                    response.ResponseMessage = "no applicant found";
                    return StatusCode(404, response);
                }
                response.Data = getApplicant;
                response.Status = true;
                response.ResponseCode = "00";
                response.ResponseMessage = "applicant found";
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed attempt getting applicant", ex);
                response.Status = false;
                response.ResponseCode = "99";
                response.ResponseMessage = "an error occured";
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<DefaultResponse<string>>> Login([FromBody] Login login)
        {
            DefaultResponse<string> response = new();
            try
            {
                var kostoma = _context.Applicants.FirstOrDefault(x => x.Username == login.Username);
                if (kostoma == null)
                {
                    response.Status = false;
                    response.ResponseMessage = "no customer found";
                    return StatusCode(404, response);
                }
                if (!BCrypt.Net.BCrypt.Verify(login.Password, kostoma.PasswordHash))
                {
                    response.Status = false;
                    response.ResponseMessage = "Invalid Password";
                    return BadRequest(response.ResponseMessage);
                }

                string token = CreateToken(kostoma);
                response.Status = true;
                response.ResponseCode = "00";
                response.ResponseMessage = "Login successful, Welcome back";
                //return Ok($"Welcome Back, {kostoma.Username}!:");
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError("Customer Login failed", ex);
                response.Status = false;
                response.ResponseCode = "99";
                response.ResponseMessage = "an error occured";
                return StatusCode(500, response);
            }
        }

        private string CreateToken(Applicants applicant)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, applicant.Username)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials,
                claims: claims
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
