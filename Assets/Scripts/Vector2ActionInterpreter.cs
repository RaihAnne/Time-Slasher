using UnityEngine;
using UnityEngine.InputSystem;

public class Vector2ActionInterpreter : ActionInterpreter
{
    private Vector2 Direction;
    public Vector2ActionInterpreter(CustomInputEvents inputEvents, string actionNameToInterpret) : base(inputEvents, actionNameToInterpret) { }

    public Vector2 GetDirection()
    {
        return Direction;
    }

    protected override void OnInput(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }
}
