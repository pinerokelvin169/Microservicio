using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.DTOs
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
