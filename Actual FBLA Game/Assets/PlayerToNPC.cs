using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerToNPC : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public DialogManager dialogManager;
    public Canvas NPC;

    public GameObject triggeringNPC;
    public bool triggering;
    public bool wave = false;


    public Animator anim;

    public GameObject npcText;

    void Start()
    {
        NPC = dialogManager.NPC;
        npcText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        anim = anim.GetComponent<Animator>();
    }

    void Update()
    {
        if (wave)
        {
            anim.SetBool("Wave", true);
        }
        else
        {
            anim.SetBool("Wave", false);
        }

        if (triggering)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                NPC.gameObject.SetActive(true);
                npcText.SetActive(false);
                Cursor.lockState = CursorLockMode.None;

                wave = true;
            }
        }
        else
        {
            NPC.gameObject.SetActive(false);
            wave = false;
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggeringNPC = null;
        }
    }
}