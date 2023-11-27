using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject _player; // ī�޶� ���� ���
    [SerializeField] private float _cameraSpeed; // ī�޶��� �ӵ�
    private Vector3 _playerPosition; // ���� ����� ��ġ

    void Start()
    {
        
    }

    void Update()
    {
        // ���� ����� null���� �ƴ��� üũ
        if (_player.gameObject != null) 
        {
            // x, y �� ���� ���� ����� ��ǥ��, z���� ī�޶�
            _playerPosition.Set(_player.transform.position.x, _player.transform.position.y, transform.position.z);

            // 2Dĳ���ʹ� �������� x,y ��鿡�� �̷���� Vector2 ����� �Ϲ���
            // ī�޶��� �������� 3D�������� �̷���� Vector3�� ���
            transform.position = Vector3.Lerp(transform.position, _playerPosition, _cameraSpeed * Time.deltaTime);
        }
    }
}
