using RiverRide.Rendering;

namespace RiverRide.CollisionDetection;

public class DefaultCollisionDetector : ICollisionDetector
{
    public void DetectCollision(RenderingContext renderingContext)
    {
        var listOfCollisions = new List<(Drawable d1, Drawable s2)>();
        foreach (var d1 in renderingContext.Drawables)
        {
            foreach (var d2 in renderingContext.Drawables)
            {
                var isCollided = CheckCollision(d1, d2);
                if (isCollided)
                {
                    listOfCollisions.Add((d1,d2));
                }
            }
        }

        foreach (var (d1, d2) in listOfCollisions)
        {
            d1.OnCollision(d2, renderingContext);            
            d2.OnCollision(d1, renderingContext);            
        }
    }

    private bool CheckCollision(Drawable d1, Drawable d2)
    {
        if (d1 == d2)
        {
            return false;
        }

        return CheckOverlapCoordinates(d1.Coordinate, d2.Coordinate);
    }

    private bool CheckOverlapCoordinates(Coordinate c1, Coordinate c2)
    {
        return c2.Left >= c1.Left && c2.Left <= c1.Left + c1.Width && c2.Top >= c1.Top && c2.Top <= c1.Top + c1.Height;
    }
}