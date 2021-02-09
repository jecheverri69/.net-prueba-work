using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    public class ResponseApi
    {
        public string ResponseType { get; set; }
        public string ResponseMessage { get; set; }
        public object ResponseObject { get; set; }
        public bool ResponseStatus { get; set; }
    }
}