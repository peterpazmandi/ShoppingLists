using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.DTOs
{
    public class MessageDto
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }
    }
}
