using Unity.Entities;
using Unity.Mathematics;

namespace BounceDOTS.Components
{
    public struct PlayerInput : IComponentData
    {
        public float2 MoveInput;
        public bool JumpInput;
    }
}