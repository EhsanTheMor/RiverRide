using RiverRide.Rendering;

namespace RiverRide.CollisionDetection;

public interface ICollisionDetector
{
    void DetectCollision(RenderingContext renderingContext);
}