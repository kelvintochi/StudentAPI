using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFirstWebApi.Models
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        
    }

    public class ResponseModel<TData>
    {

    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public TData Data { get; set; }

}
}

