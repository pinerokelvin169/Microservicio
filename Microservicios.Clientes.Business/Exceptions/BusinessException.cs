using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.Exceptions
{
    public class BusinessException : Exception
    {
        public int StatusCode { get; }

        public BusinessException(string message)
            : base(message)
        {
            StatusCode = 400; // 🔥 default (Bad Request)
        }

        public BusinessException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}