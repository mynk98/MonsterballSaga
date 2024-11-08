using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using BounceDOTS.Components;
using UnityEngine;
using Unity.Physics.Authoring;
using Unity.Physics;

namespace BounceDOTS.Systems
{
    public partial class BallMovementSystem : SystemBase
    {

        private Rigidbody body;
        // protected override void OnCreate()
        // {
        //     base.OnCreate();
        //     Entities.WithAll<BallTag>().get
        // }


        protected override void OnUpdate()
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            Entities
                .WithAll<BallTag>()
                .ForEach((ref LocalTransform transform, ref BallMovement movement,ref PhysicsVelocity physicsVelocity,in BallStats stats, in PlayerInput input) =>
                {
                    // Calculate desired velocity
                    float2 desiredVelocity = input.MoveInput * stats.MaxSpeed;
                    
                    // Apply acceleration
                    float maxSpeedChange = stats.MaxAcceleration * deltaTime;
                    movement.Velocity = math.lerp(movement.Velocity, desiredVelocity, maxSpeedChange);

                    // Calculate displacement
                    // float2 displacement = movement.Velocity * deltaTime;
                    // float3 newPosition = transform.Position + new float3(displacement.x, 0, displacement.y);

                    // // Update position
                    // transform.Position = newPosition;

                    physicsVelocity.Linear = new float3(movement.Velocity.x, 0, movement.Velocity.y); 
                }).Schedule();
        }
    }
}