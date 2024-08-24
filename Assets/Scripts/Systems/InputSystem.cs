using Unity.Entities;
using UnityEngine;
using BounceDOTS.Components;

namespace BounceDOTS.Systems
{
    public partial class InputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float2 moveInput = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            bool jumpInput = Input.GetButtonDown("Jump");

            Entities
                .WithAll<PlayerInput>()
                .ForEach((ref PlayerInput input) =>
                {
                    input.MoveInput = moveInput;
                    input.JumpInput = jumpInput;
                }).Schedule();
        }
    }
}