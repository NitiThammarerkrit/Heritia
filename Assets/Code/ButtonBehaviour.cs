﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {

    public static bool trigger;
    GameObject EventSystem;
    // Use this for initialization
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        trigger = false;
    }
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnClicked(string Scene)
    {
    
        if(Scene == "Game")
        {

          
            Time.timeScale = 1;
            StartCoroutine(Wait(50f));
            
        }
        if(Scene == "Exit")
        {
            Application.Quit();
        }
        if(Scene == "Main")
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }
        if(Scene == "Credits")
        {
            EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds * Time.deltaTime);
        SceneManager.LoadScene("Game");
    }
  
}
