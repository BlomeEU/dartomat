using Contracts.Commands;

using Dartomat.Core.Services.DataContracts;

using MassTransit;

namespace Dartomat.Core.Services.Consumers.Commands;

internal class FetchGameHandler(IGameStore gameStore) : IConsumer<FetchGame>
{
    public async Task Consume(ConsumeContext<FetchGame> context)
    {
        await context.RespondAsync(await gameStore.GetById(context.Message.Id));
    }
}
