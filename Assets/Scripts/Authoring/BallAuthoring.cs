using Unity.Entities;
using UnityEngine;
using BounceDOTS.Components;

namespace BounceDOTS.Authoring
{
    public class BallAuthoring : MonoBehaviour
    {
        public float Speed = 5f;
        public float JumpForce = 10f;
        public float Mass = 1f;
    }

    public class BallBaker : Baker<BallAuthoring>
    {
        public override void Bake(BallAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new BallTag());
            AddComponent(entity, new BallStats
            {
                Speed = authoring.Speed,
                JumpForce = authoring.JumpForce,
                Mass = authoring.Mass
            });
            AddComponent(entity, new PlayerInput());
        }
    }
}