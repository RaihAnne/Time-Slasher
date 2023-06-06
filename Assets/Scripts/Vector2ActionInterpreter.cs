using UnityEngine;
using UnityEngine.InputSystem;

public class Vector2ActionInterpreter
{
    private CustomInputEvents InputEvents;
    private string ActionName = PlayerActionMap.Move;

    private Vector2 InputDirection;

    public Vector2ActionInterpreter(CustomInputEvents inputEvents, string actionNameToInterpret)
    {
        InputEvents = inputEvents;
        ActionName = actionNameToInterpret;

        StartListening();
    }

    public Vector2 GetVector2Direction()
    {
        return InputDirection;
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        InputDirection = context.ReadValue<Vector2>(); 
    }

    private void StartListening()
    {
        InputEvents.RegisterOnStartPerformedAndCancelled(ActionName, OnInput);
    }

    private void StopListening()
    {
        InputEvents.UnregisterOnStartPerformedAndCancelled(ActionName, OnInput);

    }
}
