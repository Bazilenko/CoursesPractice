using System.Net;

namespace CoursesWeb.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message)
            : base(message,
                  null,
                  HttpStatusCode.NotFound)
        {
        }
    }
}
