using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHeal : PickupItem
{
    [SerializeField] int healValue = 10;
    private HealthSystem _healthSystem;

    protected override void OnpickUp(GameObject recriver)
    {
        _healthSystem = recriver.GetComponent<HealthSystem>();
        _healthSystem.ChangeHealth(healValue);
    }
}
