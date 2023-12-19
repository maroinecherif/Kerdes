using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;
using WebApplication1.services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VickreyAuctionController : ControllerBase
    {
        private readonly IVickreyAuctionService _vickreyAuctionService;

        public VickreyAuctionController(IVickreyAuctionService auctionService)
        {
            _vickreyAuctionService = auctionService ?? throw new ArgumentNullException(nameof(auctionService));
        }

        [HttpPost]
        public IActionResult RunVickreyAuction([FromBody] AuctionRequest request)
        {
            if (request is null || request.Bidders is null || request.ReservePrice < 0)
            {
                return BadRequest("Invalid input");
            }

            try
            {
                var result = _vickreyAuctionService.CalculateVickreyAuction(request.Bidders, request.ReservePrice);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
