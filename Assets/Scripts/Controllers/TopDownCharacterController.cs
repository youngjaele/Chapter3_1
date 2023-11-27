using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // event �ܺο��� ȣ�� ���ϰ� ���´�
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
