using UnityEngine.InputSystem;

public abstract class ActionInterpreter
{
    protected CustomInputEvents InputEvents;
    protected string ActionName;

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

    protected abstract void OnInput(InputAction.CallbackContext context);

}
