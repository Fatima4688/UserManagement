using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Common.Models.ResponseViewModel
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Response()
        {
            Success = false;
            Message = string.Empty;
        }
        public Response(string message)
        {
            Message = message;
        }
    }
}
