using System.Web.Mvc;
using System.Text.Encodings.Web;

namespace src
{
    // [RoutePrefix("api/bookings")]
    public class HellowWorldController : Controller
    {
        //
        //GET: /bookings/
         [Route("bookings")]
        [HttpGet]
        public string Index()
        {
            return "This is my default action..";
        }

        
    }
}

