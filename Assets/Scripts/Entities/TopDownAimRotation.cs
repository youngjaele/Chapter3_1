using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    // [SerializeField] private SpriteRenderer armRenderer;
    // [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    // Atan2 = Atan�� ���� ����ؼ� ��Ÿ���� ���Ѵ� ( ������ ������ ���ϴ� ��)
    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        //armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        //characterRenderer.flipX = armRenderer.flipY;
        // armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }

  
    void Update()
    {
        
    }
}