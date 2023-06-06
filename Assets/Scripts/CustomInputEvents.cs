using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputEvents : MonoBehaviour
{
    [SerializeField] private PlayerInput CustomPlayerInput;

    private Dictionary<string, InputAction> DictionaryOfActions = new Dictionary<string, InputAction>();

    private void Awake()
    {
        DictionaryOfActions.Add(PlayerActionMap.Move, GetAction(PlayerActionMap.Move));
        DictionaryOfActions.Add(PlayerActionMap.Attack, GetAction(PlayerActionMap.Attack));
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
}

public static class PlayerActionMap
{
    public const string ActionMap = "Player";
    public const string Move = "Move";
    public const string Attack = "Attack";
}
