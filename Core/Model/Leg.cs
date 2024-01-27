namespace Dartomat.Core.Domain;

public class Leg
{
    public PlayerRound[] Rounds { get; set; }
}

public record PlayerRound(Player Player, Round Round);
