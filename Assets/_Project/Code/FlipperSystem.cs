using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine.InputSystem;
using UnityEngine;

public class FlipperSystem : ComponentSystem
{
    private Keyboard keyboard;

    protected override void OnCreate()
    {
        base.OnCreate();

        keyboard = InputSystem.GetDevice<Keyboard>();
    }

    protected override void OnUpdate()
    {
        bool flipper0 = keyboard.leftArrowKey.isPressed;
        bool flipper1 = keyboard.rightArrowKey.isPressed;

        foreach (var touch in Input.touches)
        {
            if (touch.position.y <= Screen.height * 0.2f)
            {
                if (touch.position.x <= Screen.width * 0.35f)
                {
                    flipper0 = true;
                }
                else if (touch.position.x >= Screen.width * 0.65f)
                {
                    flipper1 = true;
                }
            }
        }

        Entities.ForEach((ref PhysicsVelocity velocity, ref PhysicsMass mass, ref Flipper flipper) =>
        {
            if (flipper.id == 0 && flipper0
                || flipper.id == 1 && flipper1)
            {
                Unity.Physics.Extensions.ComponentExtensions.ApplyLinearImpulse(ref velocity, mass, flipper.impulse);
            }
        });
    }
}
