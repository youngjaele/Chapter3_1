using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStatModifiers : PickupItem
{
    [SerializeField] private List<CharacterStats> statsModifier;

    protected override void OnpickUp(GameObject recriver)
    {
        CharacterStatsHandler statsHandler = recriver.GetComponent<CharacterStatsHandler>();
        foreach (CharacterStats stat in statsModifier)
        {
            statsHandler.AddStatModifier(stat);
        }
    }
}
