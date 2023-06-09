using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vector2ActionInterpreter : ActionInterpreter<Vector2>
{
    private Vector2 Direction;
    public Vector2ActionInterpreter(CustomInputEvents inputEvents, string actionNameToInterpret) : base(inputEvents, actionNameToInterpret) { }

    protected override Vector2 Interpret(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
        return Direction;
    }
}
