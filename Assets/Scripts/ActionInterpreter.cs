using System;
using UnityEngine.InputSystem;

public abstract class ActionInterpreter<T>
{
    protected CustomInputEvents InputEvents;
    protected string ActionName;

    public Action<T> OnInputInterpreted;

    public ActionInterpreter(CustomInputEvents inputEvents, string actionNameToInterpret)
    {
        InputEvents = inputEvents;
        ActionName = actionNameToInterpret;
    }

    public void StartListening()
    {
        InputEvents.RegisterOnStartPerformedAndCancelled(ActionName, OnInput);
    }

    public void StopListening()
    {
        InputEvents.UnregisterOnStartPerformedAndCancelled(ActionName, OnInput);
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        OnInputInterpreted?.Invoke(Interpret(context));
    }

    protected abstract T Interpret(InputAction.CallbackContext context);

}
