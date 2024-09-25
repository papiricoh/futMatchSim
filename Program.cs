using System.Diagnostics;
using System.Numerics;
using futMatchSim.Models;

public class Program
{
    private static Program? instance = null;
    private static Stopwatch timer = new Stopwatch();
    public static double deltaTime;
    public Field field;

    public static bool devMode = true;

    private GameManager? gameManager;


    static void Main(string[] args)
    {
        instance = getInstance();
        instance.init();
        instance.loop();
    }

    private void init()
    {
        this.field = new Field(105f, 68f);
        Team homeTeam = new Team();

        Team awayTeam = new Team();
        this.gameManager = new GameManager(homeTeam, awayTeam);
    }

    public static Program getInstance()
    {
        if(instance == null)
        {
            instance = new Program();
        }

        return instance;
    }

    public void loop()
    {
        //Initialice teams and players

        timer.Start();

        while (true)
        {
            deltaTime = timer.Elapsed.TotalSeconds;
            timer.Restart();


            UpdateSimulation(deltaTime);


            System.Threading.Thread.Sleep(50); // 50 = ~20 FPS, 32 = ~30 FPS, 16 = ~60 FPS
        }
    }


    private void UpdateSimulation(double deltaTime)
    {
        /*pe.setNewDirection(new Vector3(1, 1, 0), 5.0f);
        pe.updatePos();*/
        
    }
}