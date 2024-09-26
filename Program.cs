using System.Diagnostics;
using futMatchSim;
using futMatchSim.Models;
using futMatchSim.Utils;
using SDL2;

public class Program
{
    private static Program? instance = null;
    private static Stopwatch timer = new Stopwatch();
    public static double deltaTime;

    public static bool devMode = true;
    private static VisualManager? vm;

    private GameManager gameManager;


    static void Main(string[] args)
    {
        instance = getInstance();

        if (devMode)
        {
            vm = new VisualManager();
        }

        instance.loop();
    }

    public Program() //INIT
    {

        Team homeTeam = new Team("Madrid", "Real Madrid", PlayerGenerator.generateTeam());

        Team awayTeam = new Team("Barcelona", "FC Barcelona", PlayerGenerator.generateTeam());

        Console.WriteLine(homeTeam.tactic.players.Count);
        this.gameManager = new GameManager(homeTeam, awayTeam, null);

    }

    public static Program getInstance()
    {
        if(instance == null)
        {
            instance = new Program();
        }

        return instance;
    }

    public GameManager GetGameManager()
    {
        return this.gameManager;
    }

    public void loop()
    {
        //Initialice teams and players

        timer.Start();

        while (true)
        {
            SDL.SDL_Event e;
            while (SDL.SDL_PollEvent(out e) != 0)
            {
                if (e.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    vm!.quitScreen();
                    return;
                }
            }

            deltaTime = timer.Elapsed.TotalSeconds;
            timer.Restart();


            UpdateSimulation(deltaTime);

            if (devMode)
            {
                vm!.debugRender();
            }

            System.Threading.Thread.Sleep(50); // 50 = ~20 FPS, 32 = ~30 FPS, 16 = ~60 FPS
        }
    }



    private void UpdateSimulation(double deltaTime)
    {
        gameManager.tick(deltaTime);
    }
}