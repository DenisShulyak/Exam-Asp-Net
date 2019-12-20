using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNetWebApp.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Requests { get; set; } //У каждого пользователя сохраняются запросы
        
    }
}
