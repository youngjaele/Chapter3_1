using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // �̱���
    public static ProjectileManager instance;

    [SerializeField] private ParticleSystem _impactParticleSystyem;
    private ObjectPool objectPool;

    // �׽�Ʈ�� �Ѿ� �ּ�
    // [SerializeField] private GameObject testObj; 


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    // TopDownShooting������ CreateProjectile()�Լ� ��û�� �޾ƿͼ� Obj (�Ҹ�) ����
    // RangedAttackController(����ü ��Ʈ�ѷ�)�� ���ؼ� ������ �Ҹ� �ʱ�ȭ ����
    public void ShootBullet(Vector2 startPostion, Vector2 directionm, RangedAttackData attackData)
    {
        // GameObject obj = Instantiate(testObj); �Ϲ����� �Ҹ� ���� 
        // ������Ʈ Ǯ���� ����� �Ҹ� ���� ( ������ ������ �̸� ���� �ı� �� ���� )
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);

        obj.transform.position = startPostion;
        // ������ �Ҹ� �ʱ�ȭ ����
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(directionm, attackData, this);
        
        obj.SetActive(true); // ������ ���� SetActive
    }
}