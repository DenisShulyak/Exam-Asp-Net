using ExamAspNetWebApp.DataAccess;
using ExamAspNetWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamAspNetWebApp.Services
{
    public class GetEarthquakeService
    {


        public EarthquakeContext _context { get; }

        public GetEarthquakeService( EarthquakeContext context)
        {
            this._context = context;
        }

        public List<Earthquake> GetEarthquake(string login)
        {
            var request = "/api/Home/GetQueary";
            System.Net.WebClient client = new System.Net.WebClient();
            
            Stream stream = client.OpenRead("https://earthquake-report.com/feeds/recent-eq?json"); 
            StreamReader sr = new StreamReader(stream);

            string txt = sr.ReadLine();

            List<Earthquake> data = JsonConvert.DeserializeObject<List<Earthquake>>(txt);

            foreach(var index in _context.Users)
            {
                if(index.Login == login)
                {
                    index.Requests += "\n" + request;
                }
            }

            _context.SaveChanges();

            return data;
        }
    }
}
