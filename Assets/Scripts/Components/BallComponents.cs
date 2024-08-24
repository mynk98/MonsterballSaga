using Unity.Entities;

namespace BounceDOTS.Components
{
    public struct BallTag : IComponentData { }

    public struct BallStats : IComponentData
    {
        public float Speed;
        public float JumpForce;
        public float Mass;
    }
}