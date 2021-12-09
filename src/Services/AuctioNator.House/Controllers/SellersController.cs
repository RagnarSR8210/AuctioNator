using Microsoft.AspNetCore.Mvc;

namespace AuctioNator.House.Controllers
{
    [Route("api/h/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        public SellersController()
        {

        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--->Inbound SELLERS POST # HouseService");

            return Ok("Inbound test from Seller Controller");

        }

    }
}


