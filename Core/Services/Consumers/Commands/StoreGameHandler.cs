using Contracts.Commands;

using Dartomat.Core.Services.DataContracts;

using MassTransit;

namespace Dartomat.Core.Services.Consumers.Commands;

internal class StoreGameHandler(IGameStore gameStore) : IConsumer<StoreGame>
{
    public async Task Consume(ConsumeContext<StoreGame> context)
    {
        await gameStore.Insert(context.Message.Game);
    }
}
