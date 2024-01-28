using Contracts.Events;

using Dartomat.Core.Services.DataContracts;

using MassTransit;

using Microsoft.Extensions.Logging;

namespace Dartomat.Core.Services.Consumers.Events;

public class GamePlayedConsumer(ILogger<GamePlayedConsumer> logger, IGameStore gameStore) : IConsumer<GamePlayed>
{
    public Task Consume(ConsumeContext<GamePlayed> context)
    {
        logger.LogInformation("Received GamePlayed event! {game}", context.Message.Id);
        return Task.CompletedTask;
    }
}
