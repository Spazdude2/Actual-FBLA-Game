using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class PasueMenu : MonoBehaviour
{
    public FirstPersonController Player;
    public Sun sun;

    public Canvas pauseMenu;

	// Use this for initialization
	void Start ()
    {
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        pauseMenu.gameObject.SetActive(false);
        Player = Player.GetComponent<FirstPersonController>();
        sun = sun.GetComponent<Sun>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {

        if (pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            sun.Orbit = 0;
            Time.timeScale = 0;
            Player.enabled = false;
        }
        else if (pauseMenu.gameObject.activeInHierarchy == true)
        {
            pauseMenu.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            sun.Orbit = sun.setOrbit;
            Time.timeScale = 1;
            Player.enabled = true;
        }
    }
}
