using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // 싱글톤
    public static ProjectileManager instance;

    [SerializeField] private ParticleSystem _impactParticleSystyem;
    [SerializeField] private GameObject testObj;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // TopDownShooting에서의 CreateProjectile()함수 요청을 받아와서 Obj (불릿) 생성
    // RangedAttackController(투사체 컨트롤러)를 통해서 생성한 불릿 초기화 진행
    public void ShootBullet(Vector2 startPostion, Vector2 directionm, RangedAttackData attackData)
    {
        GameObject obj = Instantiate(testObj); // 불링 생성

        obj.transform.position = startPostion;
        // 생성한 불릿 초기화 진행
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(directionm, attackData, this);
        
        obj.SetActive(true); // 재사용을 위해 SetActive
    }
}
