using Microsoft.AspNetCore.Mvc;

namespace AuctioNator.House.Controllers
{
    [Route("api/h/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        public BuyersController()
        {

        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--->Inbound BUYERS POST # HouseService");

            return Ok("Inbound test from Buyer Controller");

        }

    }
}


