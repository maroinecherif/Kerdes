using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.models;
using WebApplication1.services;

public class VickreyAuctionService : IVickreyAuctionService
{
    public AuctionResult CalculateVickreyAuction(List<Bidder> bidders, double reservePrice)
    {
        if (bidders is null || bidders.Any(b => b.Bids is null) || reservePrice < 0)
        {
            throw new ArgumentException("Invalid input");
        }

        var qualifiedBidders = bidders.Where(b => b.Bids.Any(bid => bid >= reservePrice)).ToList();

        if (qualifiedBidders.Count == 0)
        {
            return new AuctionResult { WinningBidder = null, WinningBidPrice = reservePrice };
        }

        var winningBidPrice = qualifiedBidders
            .SelectMany(b => b.Bids.Where(bid => bid < reservePrice))
            .DefaultIfEmpty(reservePrice)
            .Max();
        var winningBidder = qualifiedBidders
            .Where(b => b.Bids.Contains(winningBidPrice))
            .FirstOrDefault();

        return new AuctionResult { WinningBidder = winningBidder?.Name, WinningBidPrice = winningBidPrice };
    }
}
