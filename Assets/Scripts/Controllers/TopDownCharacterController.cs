using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // event 외부에서 호출 못하게 막는다
    public event Action<Vector2> OnMoverEvent;
    public event Action<Vector2> OnLookEvent;
   
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoverEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
