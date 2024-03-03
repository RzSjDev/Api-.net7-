using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.net.Models
{
    public class ServiceResponse<T>
    {

        public T? Data { get; set; }
        public bool succsess { get; set; } = true;
        public string? Message { get; set; } = "";
    }

}