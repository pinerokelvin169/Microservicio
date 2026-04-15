using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.Business.DTOs;
using Microservicio.Clientes.Business.Interfaces;
using Microservicio.Clientes.Business.Exceptions;
using Microservicio.Clientes.DataManagement.Interfaces;

namespace Microservicio.Clientes.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            // 🔍 BUSCAR USUARIO CON ROLES
            var usuario = await _unitOfWork.Usuarios.GetWithRolesAsync(request.Username);

            if (usuario == null)
                throw new UnauthorizedBusinessException("Usuario o contraseña incorrectos");

            // 🔒 VALIDAR BLOQUEO
            if (usuario.Bloqueado)
                throw new UnauthorizedBusinessException("Usuario bloqueado");

            // 🔑 VALIDAR PASSWORD (SIN HASH 🔥)
            if (usuario.PasswordHash != request.Password)
            {
                await _unitOfWork.Usuarios.IncrementarIntentosFallidosAsync(usuario.IdUsuario);
                await _unitOfWork.SaveChangesAsync();

                throw new UnauthorizedBusinessException("Usuario o contraseña incorrectos");
            }

            // 🔄 RESET INTENTOS
            await _unitOfWork.Usuarios.ResetIntentosFallidosAsync(usuario.IdUsuario);

            // 🔥 EXTRAER ROLES
            var roles = usuario.UsuarioRoles
                .Select(ur => ur.Rol.Nombre)
                .ToList();

            // 🔐 TOKEN FAKE (por ahora)
            var token = "TOKEN_DE_PRUEBA_" + Guid.NewGuid();

            var expiration = DateTime.UtcNow.AddHours(1);

            await _unitOfWork.SaveChangesAsync();

            return new LoginResponse
            {
                Token = token,
                Username = usuario.Username,
                Roles = roles,
                Expiration = expiration
            };
        }
    }
}