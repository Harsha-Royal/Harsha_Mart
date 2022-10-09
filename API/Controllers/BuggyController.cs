using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(999);

            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
           var thing = _context.Products.Find(999);
           var thingToReturn = thing.ToString();
           return Ok();
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {           
           return BadRequest(new ApiResponse(400));
        }

        [HttpGet("BadRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {           
           return BadRequest(new ApiResponse(400));
        }

    }
}