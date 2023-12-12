using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // event 외부에서 호출 못하게 막는다
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler _stats { get; private set; }

    protected virtual void Awake()
    {
        _stats = GetComponent<CharacterStatsHandler>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }

    private void HandleAttackDelay()
    {
        if (_stats.CurrentStats.attackSO == null)
            return;

        if (_timeSinceLastAttack <= _stats.CurrentStats.attackSO.dealy)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        if (IsAttacking && _timeSinceLastAttack > _stats.CurrentStats.attackSO.dealy)
        { 
            _timeSinceLastAttack = 0;
            CallAttackEvent(_stats.CurrentStats.attackSO);
        }
    }
}
