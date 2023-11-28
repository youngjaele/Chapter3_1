using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(bool isMoving)
    {
        if (_animator != null)
        {
            _animator.SetBool("isMove", isMoving);
        }
        else
        {
            _animator.SetBool("isMove", false);
        }
    }
}