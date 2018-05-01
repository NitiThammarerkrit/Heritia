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
        Application.LoadLevel(scene);
        GameData.current_scene = 0;
        for (int i = 0; i < GameData.events_complete.Length; i++) { GameData.events_complete[i] = true; }
        for (int i = 0; i < GameData.gems_receive.Length; i++) { GameData.gems_receive[i] = true; }

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
