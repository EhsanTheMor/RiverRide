using RiverRide.CollisionDetection;

namespace RiverRide.Rendering;

public interface IRenderEngine
{
    Task Render(RenderingContext context, ICollisionDetector collisionDetection, CancellationToken cancellationToken);
}