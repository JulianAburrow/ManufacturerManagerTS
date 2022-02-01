using System.Net;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public class Results<T>
    {
        public T Entity { get; set; }

        public HttpStatusCode HttpStatusCode;
    }
}
