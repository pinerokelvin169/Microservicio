using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.Exceptions
{
    public class UnauthorizedBusinessException : BusinessException
    {
        public UnauthorizedBusinessException(string message)
            : base(message, 401)
        {
        }
    }
}
