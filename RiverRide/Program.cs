using RiverRide.CollisionDetection;
using RiverRide.Drawables;
using RiverRide.Rendering;

var _ctx = new CancellationTokenSource();

var renderingContext = new RenderingContext();
var boat = new Boat(renderingContext);
renderingContext.AddDrawable(boat);
var renderingEngine = new DefaultRenderEngine();
var collisionDetector = new DefaultCollisionDetector();

var random = new Random();

for (var i = 0; i < 10; i++)
{
    var left = random.Next(renderingContext.MaxWidth);
    var top = random.Next(renderingContext.MaxHeight / 2);
    var rock = new Rock(renderingContext, left, top);
    renderingContext.AddDrawable(rock);
}

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

await renderingEngine.Render(renderingContext, collisionDetector, _ctx.Token);