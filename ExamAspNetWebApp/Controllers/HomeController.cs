using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamAspNetWebApp.DataAccess;
using ExamAspNetWebApp.DTOs;
using ExamAspNetWebApp.Models;
using ExamAspNetWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspNetWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        public HomeController(GetEarthquakeService getEarthquake, EarthquakeContext context)
        {
           
            this.getEarthquake = getEarthquake;
            this._context = context;
        }

        public GetEarthquakeService getEarthquake { get; }
        public EarthquakeContext _context { get; }

        [HttpGet]
        public IActionResult GetSecureInfo()
        {
            var login = User.Claims.ToList()[0].Value;
            string request = "api/Home/GetSecureInfo";
            foreach (var index in _context.Users)
            {
                if (index.Login == login)
                {
                    index.Requests += "\n" + request;
                }
            }

            _context.SaveChanges();

            return Ok(new { data = "Авторизирован - " + login });
        }
        [HttpGet]
        public IActionResult GetQueary()
        {
            List<EarthquakeDTO> earthquake = new List<EarthquakeDTO>();
            var earthquakeData = getEarthquake.GetEarthquake(User.Claims.ToList()[0].Value);
            for (int i = 0; i < earthquakeData.Count; i++)
            {
                earthquake[i].Mag = earthquakeData[i].Magnitude;
                earthquake[i].Place = earthquakeData[i].Location;
                earthquake[i].Time = earthquakeData[i].DateTime;
            }

            return Ok(new { data = earthquake });//Вывели данные
            //return Ok(new { data = earthquake.Mag + "\n\n" + earthquake.Place + "\n\n" + earthquake.Time });
        }
    }
}