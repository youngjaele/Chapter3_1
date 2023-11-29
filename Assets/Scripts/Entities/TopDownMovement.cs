using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection = Vector2.zero;
   

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    // FixedUpdate() = ����ó���� ���� ���Ŀ� ȣ��
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    // velocity = ���ӵ��� ����
    private void ApplyMovement(Vector2 direction)
    {
        direction *= 10;

        _rigidbody.velocity = direction;
    }
}
