using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using BounceDOTS.Components;

namespace BounceDOTS.Systems
{
    public partial class BallMovementSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            Entities
                .WithAll<BallTag>()
                .ForEach((ref PhysicsVelocity velocity, in PlayerInput input, in BallStats stats) =>
                {
                    float3 movement = new float3(input.MoveInput.x, 0, input.MoveInput.y) * stats.Speed * deltaTime;
                    velocity.Linear += movement;

                    if (input.JumpInput)
                    {
                        velocity.Linear += new float3(0, stats.JumpForce, 0);
                    }
                }).Schedule();
        }
    }
}