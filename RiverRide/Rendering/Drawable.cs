namespace RiverRide.Rendering;

public abstract class Drawable
{
    public Coordinate Coordinate { get; private set; }
    public abstract char[] Characters { get; }

    public abstract void OnKeyPressed(ConsoleKey key, RenderingContext renderingContext);

    public Drawable(RenderingContext renderingContext)
    {
        Coordinate = new Coordinate(renderingContext.MaxWidth, renderingContext.MaxHeight);
    }
}

public class Coordinate
{
    private int _moveLeft;
    private int _moveTop;

    public int Left { get; private set; }
    public int Top { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    private int _maxWidth;
    private int _maxHeight;

    public Coordinate(int maxWidth, int maxHeight)
    {
        _maxWidth = maxWidth;
        _maxHeight = maxHeight;
    }

    public bool HasChanged { get; private set; }

    public void SetCenter(int left, int top)
    {
        if (Left != left)
        {
            HasChanged = true;
            Left = left;
        }

        if (Top != top)
        {
            HasChanged = true;
            Top = top;
        }
    }

    public void SetSize(int width, int height)
    {
        if (Width != width)
        {
            HasChanged = true;
            Width = width;
        }

        if (Height != height)
        {
            HasChanged = true;
            Height = height;
        }
    }

    public void SetMovement(int left, int top)
    {
        _moveLeft = left;
        _moveTop = top;
    }

    public void OnRendered()
    {
        HasChanged = false;
        if (_moveLeft != 0 || _moveTop != 0)
        {
            SetCenter(Left + _moveLeft, Top + _moveTop);
        }
    }

    public bool IsOutOfRange()
    {
        if (Left < 0 || Left > _maxWidth || Top < 0 || Top > _maxHeight)
        {
            return true;
        }

        return false;
    }
}