namespace Dartomat.Core.Domain;

public class Game
{
    public Guid Id { get; set; }

    public Player[] Players { get; set; }
    public Set[] Sets { get; set; }
}
