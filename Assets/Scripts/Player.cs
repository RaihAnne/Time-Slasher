using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CustomInputEvents InputEvents;
    private Vector2ActionInterpreter MoveInterpreter;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        MoveInterpreter = new Vector2ActionInterpreter(InputEvents, PlayerActionMap.Move);
        MoveInterpreter.StartListening();
    }

    private void OnDisable()
    {
        MoveInterpreter.StopListening();
    }

    private void Update()
    {
        MovePlayer(MoveInterpreter.GetVector2Direction());
    }

    private void MovePlayer(Vector2 direction)
    {
        gameObject.transform.Translate(direction * Time.deltaTime);
    }
}
