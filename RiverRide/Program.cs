using RiverRide.Drawables;
using RiverRide.Rendering;

var _ctx = new CancellationTokenSource();

var renderingContext = new RenderingContext();
var boat = new Boat(renderingContext);
renderingContext.AddDrawable(boat);
var renderingEngine = new DefaultRenderEngine();

_ = Task.Factory.StartNew(() =>
{
    while (true)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            renderingContext.OnKeyPressed(key.Key);

            if (key.Key == ConsoleKey.Escape)
            {
                _ctx.Cancel();
            }
        }
    }
});

await renderingEngine.Render(renderingContext, _ctx.Token);