using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    private PlayerMoveAnimationController _playerMoveAnimationController;

    private float moveInputStop = 0.1f;

    private void Awake()
    {
        _camera = Camera.main;
        _playerMoveAnimationController = GetComponent<PlayerMoveAnimationController>();
    }

    // normalized : Vector�� ���� 1�� �߶���
    // Call ����� Event : TopDownCharacterController ���� �Լ�
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);

        if (_playerMoveAnimationController != null)
        {
            _playerMoveAnimationController.MoveAnimation(moveInput.magnitude > moveInputStop);
        }
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }

}
