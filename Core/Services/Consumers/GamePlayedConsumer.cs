using Dartomat.Core.Contracts;
using Dartomat.Core.Services.DataContracts;

using MassTransit;

using Microsoft.Extensions.Logging;

namespace Dartomat.Core.Services.Consumers;

public class GamePlayedConsumer(ILogger<GamePlayedConsumer> logger, IGameStore gameStore) : IConsumer<GamePlayed>
{
    public async Task Consume(ConsumeContext<GamePlayed> context)
    {
        logger.LogInformation("Received GamePlayed event! {game}", context.Message.Game);
        await gameStore.Insert(context.Message.Game);
        await context.RespondAsync(context.Message);
    }
}
