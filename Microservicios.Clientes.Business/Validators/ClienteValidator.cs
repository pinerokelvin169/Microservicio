using System;
using System.Collections.Generic;
using System.Text;

using Microservicio.Clientes.Business.DTOs;
using Microservicio.Clientes.Business.Exceptions;

namespace Microservicio.Clientes.Business.Validators
{
    public static class ClienteValidator
    {
        // 🔥 VALIDAR CREACIÓN
        public static void ValidarCrear(CrearClienteRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Nombre))
                errors.Add("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(request.Apellido))
                errors.Add("El apellido es obligatorio");

            if (string.IsNullOrWhiteSpace(request.Cedula))
                errors.Add("La cédula es obligatoria");

            if (!string.IsNullOrWhiteSpace(request.Cedula) && request.Cedula.Length < 10)
                errors.Add("La cédula debe tener al menos 10 caracteres");

            if (!string.IsNullOrWhiteSpace(request.Correo) && !request.Correo.Contains("@"))
                errors.Add("El correo no tiene un formato válido");

            if (errors.Any())
                throw new ValidationException(errors);
        }

        // 🔥 VALIDAR ACTUALIZACIÓN
        public static void ValidarActualizar(ActualizarClienteRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Nombre))
                errors.Add("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(request.Apellido))
                errors.Add("El apellido es obligatorio");

            if (!string.IsNullOrWhiteSpace(request.Cedula) && request.Cedula.Length < 10)
                errors.Add("La cédula debe tener al menos 10 caracteres");

            if (!string.IsNullOrWhiteSpace(request.Correo) && !request.Correo.Contains("@"))
                errors.Add("El correo no tiene un formato válido");

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }
}