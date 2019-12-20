using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNetWebApp.Models
{
    public class Earthquake : Entity
    {

        public string Title { get; set; }
        public string Magnitude { get; set; }
        public string Location { get; set; }
        public string Depth { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime DateTime { get; set; }
        public string Link { get; set; }


    }
}
