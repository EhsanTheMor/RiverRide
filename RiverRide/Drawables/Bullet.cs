using RiverRide.Rendering;

namespace RiverRide.Drawables;

public class Bullet : Drawable
{
    public Bullet(RenderingContext renderingContext, Boat boat) : base(renderingContext)
    {
        Coordinate.SetSize(1, 1);
        Coordinate.SetCenter(boat.Coordinate.Left + 2, boat.Coordinate.Top - 1);
        Coordinate.SetMovement(0, -1);
    }

    public override char[] Characters => new[] { '.' };
}