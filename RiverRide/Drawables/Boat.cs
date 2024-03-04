using RiverRide.Rendering;

namespace RiverRide.Drawables;

public class Boat : Drawable
{
    public Boat(RenderingContext renderingContext) : base(renderingContext)
    {
        Coordinate.SetCenter(renderingContext.MaxWidth / 2 - 3, renderingContext.MaxHeight - 6);
        Coordinate.SetSize(5, 5);
    }

    public override char[] Characters => new[]
    {
        ' ', ' ', '^', ' ', ' ',
        ' ', '|', ' ', '|', ' ',
        '-', '|', ' ', '|', '-',
        ' ', '|', ' ', '|', ' ',
        ' ', ' ', '^', ' ', ' ',
    };

    public override void OnKeyPressed(ConsoleKey key, RenderingContext renderingContext)
    {
        switch (key)
        {
            case ConsoleKey.W:
                Coordinate.SetCenter(Coordinate.Left, Coordinate.Top - 1);
                return;
            case ConsoleKey.D:
                Coordinate.SetCenter(Coordinate.Left + 1, Coordinate.Top);
                return;
            case ConsoleKey.S:
                Coordinate.SetCenter(Coordinate.Left, Coordinate.Top + 1);
                return;
            case ConsoleKey.A:
                Coordinate.SetCenter(Coordinate.Left - 1, Coordinate.Top);
                return;
            case ConsoleKey.Spacebar:
                var bullet = new Bullet(renderingContext, this);
                renderingContext.AddDrawable(bullet);
                return;
        }
    }
}