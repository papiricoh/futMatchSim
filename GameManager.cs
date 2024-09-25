using futMatchSim.Models;

public class GameManager
{
    public Team homeTeam { get; set; }
    public Team awayTeam { get; set; }

    public GameManager(Team home, Team away)
    {
        this.homeTeam = home;
        this.awayTeam = away;
    }

}