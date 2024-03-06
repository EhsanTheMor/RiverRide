using System.Diagnostics;
using RiverRide.CollisionDetection;

namespace RiverRide.Rendering;

public class DefaultRenderEngine : IRenderEngine
{
    public async Task Render(RenderingContext context, ICollisionDetector collisionDetection, CancellationToken cancellationToken)
    {
        Console.CursorVisible = false;


        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(16);

            var sw = Stopwatch.StartNew();

            var byteArray = new char[context.MaxWidth * context.MaxHeight];

            for (var i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = ' ';
            }

            var drawablesToRemove = new List<Drawable>();

            collisionDetection.DetectCollision(context);

            foreach (var drawable in context.Drawables)
            {
                Draw(context, drawable, byteArray.AsSpan());

                if (drawable.Coordinate.IsOutOfRange())
                {
                    drawablesToRemove.Add(drawable);
                }
            }

            foreach (var drawable in drawablesToRemove)
            {
                context.RemoveDrawable(drawable);
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(byteArray);
            Console.SetCursorPosition(0, 0);
            Console.Write(sw.ElapsedMilliseconds);
        }
    }

    private void Draw(RenderingContext renderingContext, Drawable drawable, Span<char> span)
    {
        for (var i = 0; i < drawable.Characters.Length; i++)
        {
            var row = i / drawable.Coordinate.Width;
            var col = i % drawable.Coordinate.Width;
            var offset = (drawable.Coordinate.Top + row) * renderingContext.MaxWidth + (drawable.Coordinate.Left + col);

            if (offset < 0 || offset > span.Length)
            {
                continue;
            }

            span[offset] = drawable.Characters[i];
        }

        drawable.Coordinate.OnRendered();
    }
}