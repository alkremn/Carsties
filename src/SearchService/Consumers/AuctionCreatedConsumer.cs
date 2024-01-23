using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _autoMapper;

    public AuctionCreatedConsumer(IMapper autoMapper)
    {
        _autoMapper = autoMapper;
    }
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("--> Consuming auction created: " + context.Message.Id);

        var item = _autoMapper.Map<Item>(context.Message);

        if (item.Model == "Foo") throw new ArgumentException();
        
        await item.SaveAsync();
    }
}
