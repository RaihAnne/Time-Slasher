using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputEvents : MonoBehaviour
{
    [SerializeField] private PlayerInput CustomPlayerInput;

    private Dictionary<string, InputAction> DictionaryOfActions = new Dictionary<string, InputAction>();

    public static Action<Vector2> OnMove;
    public static Action<bool> OnStopTime;

    private Vector2ActionInterpreter MoveInterpreter;
    private BooleanActionInterpreter StopTimeInterpreter;

    private void Awake()
    {
        DictionaryOfActions.Add(PlayerActionMap.Move, GetAction(PlayerActionMap.Move));
        DictionaryOfActions.Add(PlayerActionMap.StopTime, GetAction(PlayerActionMap.StopTime));

        MoveInterpreter = new Vector2ActionInterpreter(this, PlayerActionMap.Move);
        StopTimeInterpreter = new BooleanActionInterpreter(this, PlayerActionMap.StopTime);

        MoveInterpreter.OnInputInterpreted += OnMoveDetected;
        StopTimeInterpreter.OnInputInterpreted += OnStopTimeDetected;

        MoveInterpreter.StartListening();
        StopTimeInterpreter.StartListening();
    }


    public void RegisterOnStartPerformedAndCancelled(string actionName , Action<InputAction.CallbackContext> callback)   
    {
        var someAction = GetAction(actionName);

        if (someAction == null)
        {
            return;
        }

        someAction.started += callback;
        someAction.performed += callback;
        someAction.canceled += callback;
    }

    public void UnregisterOnStartPerformedAndCancelled(string actionName, Action<InputAction.CallbackContext> callback)
    {
        var someAction = GetAction(actionName);

        if (someAction == null)
        {
            return;
        }

        someAction.started -= callback;
        someAction.performed -= callback;
        someAction.canceled -= callback;
    }


    private InputAction GetAction(string actionName)
    {
        if (DictionaryOfActions.TryGetValue(actionName, out InputAction resultInputAction))
        {
            return resultInputAction;
        }

        return CustomPlayerInput.actions[actionName];
    }  

    private void OnMoveDetected(Vector2 direction)
    {
        OnMove?.Invoke(direction);
    }

    private void OnStopTimeDetected(bool isPressing)
    {
        OnStopTime?.Invoke(isPressing);
    }
}

public static class PlayerActionMap
{
    public const string ActionMap = "Player";
    public const string Move = "Move";
    public const string StopTime = "StopTime";
}
