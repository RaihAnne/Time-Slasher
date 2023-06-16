using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        CustomInputEvents.OnMove += MovePlayer;
        CustomInputEvents.OnStopTime += StopTime;
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
