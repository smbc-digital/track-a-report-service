using System;

namespace track_a_report_service.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(string message) : base(message) { }

        public virtual int Status { get; set; } = 500;
    }
}
