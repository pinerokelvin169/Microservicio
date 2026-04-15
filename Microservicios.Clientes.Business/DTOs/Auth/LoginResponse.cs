using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.DTOs
{
    public class LoginResponse
    {
        // 🔐 TOKEN
        public string Token { get; set; }

        // 🔹 INFO USUARIO
        public string Username { get; set; }

        public List<string> Roles { get; set; }

        // 🔹 EXPIRACIÓN (PRO 🔥)
        public DateTime Expiration { get; set; }
    }
}