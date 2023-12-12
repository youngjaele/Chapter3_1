using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    [SerializeField] private GameObject bankNpc;
    [SerializeField] private Canvas npcChat;
    [SerializeField] private GameManager gameManager;

    private bool playerInRange;

    private void Start()
    {
        npcChat.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(bankNpc && playerInRange && Input.GetKeyDown(KeyCode.X))
        {
            gameManager.ShowBankUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerInRange = true;
            npcChat.transform.position = transform.position + new Vector3(0, 1f, 0);
            npcChat.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerInRange = false;

            npcChat.gameObject.SetActive(false);
        }
    }
}
