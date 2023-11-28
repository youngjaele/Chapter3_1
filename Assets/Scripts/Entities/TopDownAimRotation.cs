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
        _controller.OnMoveEvent += OnMoveRotation;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void OnMoveRotation(Vector2 newMoveDirection)
    {
        RotateCharacter(newMoveDirection);
    }

    // Atan2 = Atan의 값을 계산해서 세타값을 구한다 ( 백터의 각도를 구하는 것)
    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        //armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        //characterRenderer.flipX = armRenderer.flipY;
        // armPivot.rotation = Quaternion.Euler(0, 0, rotZ);

    }

    private void RotateCharacter(Vector2 direction)
    {
        
        if (direction.x != 0)
        {
            characterRenderer.flipX = direction.x < 0;
        }

        // float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
