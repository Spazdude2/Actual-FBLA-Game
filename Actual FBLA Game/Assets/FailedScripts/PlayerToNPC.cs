using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerToNPC : MonoBehaviour
{
    public FirstPersonController Player;

    public DialogueTrigger dialogueTrigger;
    public DialogManager dialogManager;
    public Dialog dialog;
    public Canvas NPC;

    public GameObject triggeringNPC;
    public bool triggering;

    public GameObject npcText;

    void Start()
    {
        Player = Player.GetComponent<FirstPersonController>();
        NPC = dialogManager.NPC;
        npcText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        dialogManager = dialogManager.GetComponent<DialogManager>();
    }

    void Update()
    {
        if (NPC.gameObject.activeInHierarchy == true)
        {
            Player.enabled = false;
        }
        else
        {
            Player.enabled = true;
        }

        if (triggering)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                NPC.gameObject.SetActive(true);
                npcText.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            NPC.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        npcText.SetActive(true);
        if (other.tag == "NPC")
        {
            triggering = true;
            triggeringNPC = other.gameObject;
            dialogueTrigger = other.gameObject.GetComponent<DialogueTrigger>();
            StopAllCoroutines();

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggeringNPC = null;
            dialogueTrigger = null;
        }
    }
}