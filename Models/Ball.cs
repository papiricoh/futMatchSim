using System.Numerics;
using futMatchSim.Models;

public class Ball
{
    private Vector3 position;
    public Vector3 direction;
    public float speed;
    public PlayerEntity? lastPlayer;
    public PlayerEntity? assistPlayer;
    public bool onPosesion;


    public Ball()
    {
        this.onPosesion = true;
    }

    public Vector3 updatePos()
    {
        this.position += this.direction * this.speed * (float)Program.deltaTime;

        if(this.position.Z < 0)
        {
            this.position.Z = 0;
            this.speed = this.speed / 2;
            this.direction.Z = Math.Abs(-(this.direction.Z / 2));
        }

        if (Program.devMode)
        {
            Console.WriteLine("Ball is on " + this.position);
        }

        return this.position;
    }

    public void kickBall(Vector3 dir, float speed, PlayerEntity player)
    {
        this.direction = dir;
        this.speed = speed;
        this.assistPlayer = this.lastPlayer;
        this.lastPlayer = player;
    }

    public void playerPossesionUpdatePos(Vector3 pos, Vector3 dir, float speed)
    {
        this.position = pos;
        this.direction = dir;
        this.speed = speed;
    }


    public Vector3 getPosition()
    {
        return this.position;
    }
}