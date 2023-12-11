using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // 싱글톤
    public static ProjectileManager instance;

    [SerializeField] private ParticleSystem _impactParticleSystem;
    private ObjectPool objectPool;

    // 테스트용 총알 주석
    // [SerializeField] private GameObject testObj; 


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    // TopDownShooting에서의 CreateProjectile()함수 요청을 받아와서 Obj (불릿) 생성
    // RangedAttackController(투사체 컨트롤러)를 통해서 생성한 불릿 초기화 진행
    public void ShootBullet(Vector2 startPostion, Vector2 directionm, RangedAttackData attackData)
    {
        // GameObject obj = Instantiate(testObj); 일반적인 불링 생성 
        // 오브젝트 풀링을 사용한 불릿 생성 ( 정해진 갯수를 미리 생산 파괴 시 재사용 )
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);

        obj.transform.position = startPostion;
        // 생성한 불릿 초기화 진행
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(directionm, attackData, this);
        
        obj.SetActive(true); // 재사용을 위해 SetActive
    }

    public void CreateImpactParticlesAtPosition(Vector3 position, RangedAttackData attackData)
    {
        _impactParticleSystem.transform.position = position;
        ParticleSystem.EmissionModule em = _impactParticleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(attackData.size * 5)));
        ParticleSystem.MainModule mainModule = _impactParticleSystem.main;
        mainModule.startSpeedMultiplier = attackData.size * 10f;
        _impactParticleSystem.Play();
    }
}
