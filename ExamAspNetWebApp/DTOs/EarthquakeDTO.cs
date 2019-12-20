using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNetWebApp.DTOs
{
    public class EarthquakeDTO
    {
        public string Mag { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
    }
}
