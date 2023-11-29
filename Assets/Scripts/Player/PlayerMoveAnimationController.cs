using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimationController : MonoBehaviour
{
    PlayerInputController controller;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
    }

    void Start()
    {
        controller.OnMoveEvent += MoveAnimation;
    }
    void MoveAnimation(Vector2 dir)
    {
        animator.SetBool("isMove", dir.magnitude > 0f);

    }
}