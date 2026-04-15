using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.Exceptions
{
    public class ValidationException : BusinessException
    {
        public List<string> Errors { get; }

        public ValidationException(string message)
            : base(message, 400)
        {
            Errors = new List<string> { message };
        }

        public ValidationException(List<string> errors)
            : base("Errores de validación", 400)
        {
            Errors = errors;
        }
    }
}