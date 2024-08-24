using Unity.Entities;
using Unity.Mathematics;

namespace BounceDOTS.Components
{
    public struct BallTag : IComponentData { }

    public struct BallStats : IComponentData
    {
        public float MaxSpeed;
        public float MaxAcceleration;
        public float Bounciness;
    }

    public struct BallMovement : IComponentData
    {
        public float2 Velocity;
    }

    public struct AllowedArea : IComponentData
    {
        public float2 Min;
        public float2 Max;
    }
}