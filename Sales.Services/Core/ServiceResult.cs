using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AppServices.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
        public dynamic? Data { get; set; }
    }
}
