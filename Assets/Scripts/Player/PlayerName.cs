using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(target.position + Vector3.up * 0.9f);
        
        playerNameText.rectTransform.position = namePos;
    }


}
