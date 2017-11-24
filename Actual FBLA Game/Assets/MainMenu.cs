using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Canvas quit;

	public Button yes;
	public Button no;
	public Button play;
	public Button exit;

	void Start()
	{
		quit = quit.GetComponent<Canvas> ();
		quit.enabled = false;

		yes = yes.GetComponent<Button> ();
		no = no.GetComponent<Button> ();
		play = play.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();
	}

	public void OnStartGame()
	{
		Debug.Log ("You pressed Start!");

		SceneManager.LoadScene (0);
	}

	public void Play()
	{
		SceneManager.LoadScene (1);
	}

	public void Exit()
	{
		play.enabled = false;
		exit.enabled = false;
		quit.enabled = true;
	}
		
	public void LeaveGame()
	{
		Application.Quit();
	}

	public void NoPress()
	{
		play.enabled = true;
		exit.enabled = true;
		quit.enabled = false;
	}




}
