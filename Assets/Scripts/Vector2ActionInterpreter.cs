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
    }

    public Vector2 GetVector2Direction()
    {
        return InputDirection;
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        InputDirection = context.ReadValue<Vector2>(); 
    }

    public void StartListening()
    {
        InputEvents.RegisterOnStartPerformedAndCancelled(ActionName, OnInput);
    }

    public void StopListening()
    {
        InputEvents.UnregisterOnStartPerformedAndCancelled(ActionName, OnInput);
    }
}
