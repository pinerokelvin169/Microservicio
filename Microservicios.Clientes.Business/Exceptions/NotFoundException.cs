using System;
using System.Collections.Generic;
using System.Text;

using Microservicio.Clientes.Business.Exceptions;

namespace Microservicio.Clientes.Business.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException(string message)
            : base(message, 404)
        {
        }
    }
}
