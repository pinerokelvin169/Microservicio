using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.Business.DTOs;

namespace Microservicio.Clientes.Business.Interfaces
{
    public interface IAuthService
    {
        // 🔐 LOGIN
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}