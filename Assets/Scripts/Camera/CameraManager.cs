using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject _player; // 카메라가 따라갈 대상
    [SerializeField] private float _cameraSpeed; // 카메라의 속도
    private Vector3 _playerPosition; // 따라갈 대상의 위치

    void Start()
    {
        
    }

    void Update()
    {
        // 따라갈 대상이 null인지 아닌지 체크
        if (_player.gameObject != null) 
        {
            // x, y 의 값은 따라갈 대상의 좌표값, z값은 카메라값
            _playerPosition.Set(_player.transform.position.x, _player.transform.position.y, transform.position.z);

            // 2D캐릭터는 움직임이 x,y 평면에서 이루어짐 Vector2 사용이 일반적
            // 카메라의 움직임은 3D공간에서 이루어짐 Vector3를 사용
            transform.position = Vector3.Lerp(transform.position, _playerPosition, _cameraSpeed * Time.deltaTime);
        }
    }
}
