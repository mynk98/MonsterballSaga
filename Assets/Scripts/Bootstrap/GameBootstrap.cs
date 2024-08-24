using Unity.Entities;
using UnityEngine;
using BounceDOTS.Systems;

namespace BounceDOTS.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        public void Start()
        {
            DefaultWorldInitialization.Initialize("Default World", false);
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<InputSystem>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BallMovementSystem>();
            //World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<CameraFollowSystem>();
        }
    }
}