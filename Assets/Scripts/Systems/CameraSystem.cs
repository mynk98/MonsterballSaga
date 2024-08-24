using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Physics;
using BounceDOTS.Components;

namespace BounceDOTS.Systems
{
    public partial class CameraFollowSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entity mainCamera = SystemAPI.GetSingletonEntity<Camera>();
            
            Entities
                .WithAll<BallTag>()
                .ForEach((in Translation ballPosition, in PhysicsVelocity ballVelocity) =>
                {
                    float3 cameraPosition = ballPosition.Value + new float3(0, 5, -10);
                    float3 lookAtPosition = ballPosition.Value + ballVelocity.Linear;

                    SystemAPI.SetComponent(mainCamera, new Translation { Value = cameraPosition });
                    SystemAPI.SetComponent(mainCamera, new Rotation { Value = quaternion.LookRotation(lookAtPosition - cameraPosition, math.up()) });
                }).Run();
        }
    }
}