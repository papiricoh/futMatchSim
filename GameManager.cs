using futMatchSim.Models;

public class GameManager
{
    public Team homeTeam { get; set; }
    public Team awayTeam { get; set; }
    public Field field;
    public Ball ball;

    public GameManager(Team home, Team away, Field? field)
    {
        this.homeTeam = home;
        this.awayTeam = away;
        this.field = field ?? new Field(105, 64);
        this.ball = new Ball();
        this.awayTeam.flipPlayersPos();
    }


    public void tick(double deltaTime)
    {

    }

    internal List<PlayerEntity> getAllPlayers()
    {
        List<PlayerEntity> pList = new List<PlayerEntity>();
        foreach(PlayerEntity player in homeTeam.tactic.players.Keys)
        {
            pList.Add(player);
        }
        foreach (PlayerEntity player in awayTeam.tactic.players.Keys)
        {
            pList.Add(player);
        }

        return pList;
    }

    internal List<PlayerEntity> getHomePlayers()
    {
        List<PlayerEntity> pList = new List<PlayerEntity>();
        foreach (PlayerEntity player in homeTeam.tactic.players.Keys)
        {
            pList.Add(player);
        }

        return pList;
    }


    internal List<PlayerEntity> getAwayPlayers()
    {
        List<PlayerEntity> pList = new List<PlayerEntity>();
        foreach (PlayerEntity player in awayTeam.tactic.players.Keys)
        {
            pList.Add(player);
        }

        return pList;
    }
}