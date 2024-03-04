namespace RiverRide.Rendering;

public interface IRenderEngine
{
    Task Render(RenderingContext context, CancellationToken cancellationToken);
}