namespace RiverRide.Rendering;

public class RenderingContext
{
    private readonly List<Drawable> _drawables;
    public IReadOnlyList<Drawable> Drawables => _drawables.AsReadOnly();

    public int MaxWidth { get; }
    public int MaxHeight { get; }

    public RenderingContext()
    {
        _drawables = new List<Drawable>();
        MaxWidth = Console.BufferWidth;
        MaxHeight = Console.BufferHeight;
    }

    public void AddDrawable(Drawable drawable)
    {
        _drawables.Add(drawable);
    }

    public void RemoveDrawable(Drawable drawable)
    {
        _drawables.Remove(drawable);
    }

    public void OnKeyPressed(ConsoleKey key)
    {
        var currentDrawables = _drawables.ToList();
        foreach (var drawable in currentDrawables)
        {
            drawable.OnKeyPressed(key, this);
        }
    }
}