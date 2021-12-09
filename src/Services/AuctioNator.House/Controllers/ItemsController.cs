using Microsoft.AspNetCore.Mvc;

namespace AuctioNator.House.Controllers
{
    [Route("api/h/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController()
        {

        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--->Inbound ITEM POST # HouseService");

            return Ok("Inbound test from Items Controller");

        }

    }
}


