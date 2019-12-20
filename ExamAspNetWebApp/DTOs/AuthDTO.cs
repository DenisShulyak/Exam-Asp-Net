using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNetWebApp.DTOs
{
    public class AuthDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
