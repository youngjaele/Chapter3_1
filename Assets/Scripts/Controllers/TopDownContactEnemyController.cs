using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRnage;
    [SerializeField] private string targetTag = "Player";
    private bool _isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    private HealthSystem healthSystem;
    private HealthSystem _collidingTargetHealthSystem;
    private TopDownMovement _collidingMovement;

    protected override void Start()
    {
        base.Start();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        followRnage = 100f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_isCollidingWithTarget)
        {
            ApplyHealthChange();
        }

        Vector2 direction = Vector2.zero;
        if(DistanceToTarget() < followRnage)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2 (direction.y, direction.x) *Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject recriver = collision.gameObject;

        if(!recriver.CompareTag(targetTag))
        {
            return;
        }

        _collidingTargetHealthSystem = recriver.GetComponent<HealthSystem>();
        if (_collidingTargetHealthSystem != null)
        {
            _isCollidingWithTarget = true;
        }

        _collidingMovement = recriver.GetComponent<TopDownMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag(targetTag))
        {
            return;
        }

        _isCollidingWithTarget = false;
    }

    private void ApplyHealthChange()
    {
        AttackSO attackSO = _stats.CurrentStats.attackSO;
        bool hasBeenChanged = _collidingTargetHealthSystem.ChangeHealth(-attackSO.power);
        if (attackSO.isOnKnockback && _collidingMovement != null)
        {
            _collidingMovement.ApplyKnockback(transform, attackSO.knockbackPower, attackSO.knockbackTime);
        }
    }
}
