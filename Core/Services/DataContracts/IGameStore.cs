using Dartomat.Core.Domain;

namespace Dartomat.Core.Services.DataContracts;

public interface IGameStore
{
    public Task<Game> GetById(Guid id);
    public IEnumerable<Game> GetAll();

    public Task Insert(Game game);
    public Task Update(Game game);
}
