using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Util
{
    public class ServiceException : Exception
    {
        // http response code
        public int ResponseCode { get; set; }

        public ServiceException()
        {

        }

        public ServiceException(int code, string message) : base(message)
        {
            ResponseCode = code;
        }
    }
}
