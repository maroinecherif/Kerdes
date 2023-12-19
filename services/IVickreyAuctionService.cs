using WebApplication1.models;

namespace WebApplication1.services
{
    public interface IVickreyAuctionService
    {
        AuctionResult CalculateVickreyAuction(List<Bidder> bidders, double reservePrice);
    }
}
