using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour {

   public GameObject cutscene; 

	// Use this for initialization
	void Start () {
        if (cutscene != null)
            cutscene.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public void NewGame()
    {
        cutscene.SetActive(true);
        Time.timeScale = 1;
        GameData.pass_tutorial = false;
        GameData.current_scene = 1;
        GameData.previous_scene = 1;
        for (int i = 0; i < 8; i++)
        {
            GameData.events_complete[i] = false;
            GameData.gems_receive = 0;
            GameData.items[i] = "";
            GameData.pass_tutorial = false;
        }   
        SaveLoad.Save();
        StartCoroutine(DelayBeforeGo());
    }
    public void Loadlv()
    {
        Application.LoadLevel(GameData.current_scene);
        SaveLoad.Load();
    }
    public void Loadscene(string map)
    {
        Application.LoadLevel(map);
        SaveLoad.Save();
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
    public void Backfromsetting()
    {
        Application.LoadLevel("Menu");
    }

    IEnumerator DelayBeforeGo ()
    {
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel("Cutscene");
    }
}
