using Unity.Entities;
using UnityEngine;
using BounceDOTS.Components;
using Unity.Mathematics;

namespace BounceDOTS.Authoring
{
    public class BallAuthoring : MonoBehaviour
    {
        public float MaxSpeed = 10f;
        public float MaxAcceleration = 10f;
        public float Bounciness = 0.5f;
    }

    public class BallBaker : Baker<BallAuthoring>
    {
        public override void Bake(BallAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new BallTag());
            AddComponent(entity, new BallStats
            {
                MaxSpeed = authoring.MaxSpeed,
                MaxAcceleration = authoring.MaxAcceleration,
                Bounciness = authoring.Bounciness
            });
            AddComponent(entity, new BallMovement { Velocity = float2.zero });
            AddComponent(entity, new PlayerInput());
        }
    }
}