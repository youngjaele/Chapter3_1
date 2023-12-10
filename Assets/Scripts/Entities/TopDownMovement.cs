using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private CharacterStatsHandler _stats;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection = Vector2.zero;

    private Vector2 _knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;
   

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _stats = GetComponent<CharacterStatsHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    // FixedUpdate() = 물리처리가 끝난 이후에 호출
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power ;
    }

    // velocity = 가속도를 저장
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStats.speed;
        if (knockbackDuration > 0.0f)
        {
            direction += _knockback;
        }
        _rigidbody.velocity = direction;
    }
}
