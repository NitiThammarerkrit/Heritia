using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void NewGame(string scene)
    {
        GameData.current_scene = 0;
        for (int i = 0; i < 100; i++) { GameData.events_complete[i] = false; }
        SaveLoad.Save();
        for (int i =0; i < 10; i++) { GameData.items[i] = null; }
        SaveLoad.Save();
        Application.LoadLevel(scene);
    }
    public void Loadlv()
    {
        SaveLoad.Load();
    }
    public void Savelv()
    {
        SaveLoad.Save();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Back()
    {
        Time.timeScale = 1.0f;
        GameObject.FindGameObjectWithTag("Panel").gameObject.SetActive(false);
    }
}
