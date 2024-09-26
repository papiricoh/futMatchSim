using System.Numerics;

public class Field
{

    public float height;
    public float heightLimit;
    public float width;
    public float widthLimit;

    public Field(float height, float width)
    {
        this.height = height;
        this.heightLimit = height / 2;
        this.width = width;
        this.widthLimit = width / 2;
    }

    public bool isOutOfField(Vector3 ballPos)
    {

        if (ballPos.X < - heightLimit || ballPos.X > heightLimit || ballPos.Y < - widthLimit || ballPos.Y > widthLimit)
        {
            return true;
        }
        return false;
    }

    public bool isGoal(Vector3 ballPos)
    {
        float goalLimitY = 7.32f / 2;

        if ((ballPos.X >= this.heightLimit || ballPos.X <= - this.heightLimit) &&
            ballPos.Y >= - goalLimitY && ballPos.Y <= goalLimitY && ballPos.Z < 2.44f )// 2.44f <= goalHeight
        {
            return true;
        }
        return false;
    }

}