using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamAspNetWebApp.DataAccess;
using ExamAspNetWebApp.DTOs;
using ExamAspNetWebApp.Models;
using ExamAspNetWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspNetWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public EarthquakeContext _context { get; }

        public AuthController(AuthService authService, EarthquakeContext context)
        {
            this.authService = authService;
            this._context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthDTO authDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await authService.Authenticate(authDTO.Login, authDTO.Password);
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
        
        [HttpPost]
        public ActionResult Registration(AuthDTO authDTO)
        {
            var users = _context.Users.ToList();
            foreach (var us in users)
            {
                if (us.Login == authDTO.Login)
                {
                    return BadRequest();
                }
            }
            _context.Users.AddRange(new User { Login = authDTO.Login, Password = authDTO.Password });
            _context.SaveChanges();

            return Ok("Save User - " + authDTO.Login);
        }
    }
}