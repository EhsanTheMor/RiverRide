using RiverRide.Rendering;

namespace RiverRide.Drawables;

public class Rock : Drawable
{
    public Rock(RenderingContext renderingContext, int left, int top) : base(renderingContext)
    {
        Coordinate.SetCenter(left, top);
        Coordinate.SetSize(3, 1);
    }

    public override char[] Characters => new[] { '|', '-', '|' };

    public override void OnCollision(Drawable drawable, RenderingContext renderingContext)
    {
        if (drawable is Bullet)
        {
            renderingContext.RemoveDrawable(this);
            renderingContext.RemoveDrawable(drawable);
        }
    }
}