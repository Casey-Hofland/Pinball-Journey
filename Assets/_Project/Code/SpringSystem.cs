using Unity.Entities;
using Unity.Physics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpringSystem : ComponentSystem
{
    private Keyboard keyboard;
    private Touchscreen touchscreen;

    protected override void OnCreate()
    {
        base.OnCreate();

        keyboard = InputSystem.GetDevice<Keyboard>();
    }

    protected override void OnUpdate()
    {
        bool spacePressed = keyboard.spaceKey.isPressed;

        foreach (var touch in Input.touches)
        {
            if (touch.position.y >= Screen.height * 0.75f)
            {
                spacePressed = true;
                break;
            }
        }

        Entities.ForEach((ref PhysicsVelocity velocity, ref Spring spring) =>
        {
            velocity.Linear = (spacePressed)
                ? -spring.compressForce * spring.direction
                : spring.releaseForce * spring.direction;
        });
    }
}
