using UnityEngine.InputSystem;

public class BooleanActionInterpreter : ActionInterpreter<bool>
{
    private bool IsPressed = false;

    public BooleanActionInterpreter(CustomInputEvents inputEvents, string actionNameToInterpret) : base(inputEvents, actionNameToInterpret) { }

    protected override bool Interpret(InputAction.CallbackContext context)
    {
        IsPressed = context.ReadValueAsButton();
        return IsPressed;
    }
}