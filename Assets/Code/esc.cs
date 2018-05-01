using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class esc : MonoBehaviour {

    private bool pause;
    public GameObject setting;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1.0f;
        pause = false;
        setting.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            pause = !pause;
            if(pause)
            {
                Time.timeScale = 0.0f;
                setting.gameObject.SetActive(true);
            }  
            else if(!pause)
            {
                Time.timeScale = 1.0f;
                setting.gameObject.SetActive(false);
            }
        }

    }

}
