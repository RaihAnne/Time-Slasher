using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 moveDirection;
    private void Awake()
    {
        CustomInputEvents.OnMove += OnInputMove;
        CustomInputEvents.OnStopTime += StopTime;
    }

    private void OnDisable()
    {
        CustomInputEvents.OnMove -= OnInputMove;
        CustomInputEvents.OnStopTime -= StopTime;
    }

    private void Update()
    {
        MovePlayer(moveDirection);
    }

    private void OnInputMove(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void MovePlayer(Vector2 direction)
    {
        gameObject.transform.Translate(direction * Time.deltaTime);
        Debug.Log("direction = " + direction);
    }

    private void StopTime(bool isStoppingTime)
    {
        Debug.Log("stopping Time: " + isStoppingTime);
    }
}
