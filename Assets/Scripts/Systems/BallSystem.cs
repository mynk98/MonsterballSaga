using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
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
                .ForEach((ref LocalTransform transform, ref BallMovement movement, in BallStats stats, in PlayerInput input, in AllowedArea area) =>
                {
                    // Calculate desired velocity
                    float2 desiredVelocity = input.MoveInput * stats.MaxSpeed;
                    
                    // Apply acceleration
                    float maxSpeedChange = stats.MaxAcceleration * deltaTime;
                    movement.Velocity = math.lerp(movement.Velocity, desiredVelocity, maxSpeedChange);

                    // Calculate displacement
                    float2 displacement = movement.Velocity * deltaTime;
                    float3 newPosition = transform.Position + new float3(displacement.x, 0, displacement.y);

                    // Handle bouncing
                    if (newPosition.x < area.Min.x)
                    {
                        newPosition.x = area.Min.x;
                        movement.Velocity.x = -movement.Velocity.x * stats.Bounciness;
                    }
                    else if (newPosition.x > area.Max.x)
                    {
                        newPosition.x = area.Max.x;
                        movement.Velocity.x = -movement.Velocity.x * stats.Bounciness;
                    }

                    if (newPosition.z < area.Min.y)
                    {
                        newPosition.z = area.Min.y;
                        movement.Velocity.y = -movement.Velocity.y * stats.Bounciness;
                    }
                    else if (newPosition.z > area.Max.y)
                    {
                        newPosition.z = area.Max.y;
                        movement.Velocity.y = -movement.Velocity.y * stats.Bounciness;
                    }

                    // Update position
                    transform.Position = newPosition;
                }).Schedule();
        }
    }
}