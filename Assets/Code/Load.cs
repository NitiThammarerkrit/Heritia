using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour {

    public GameObject cutscene; 

	// Use this for initialization
	void Start () {
        cutscene.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (cutscene.activeSelf == true)
        {
            if (Input.GetKey("z") || Input.GetKey("space"))
            {
                Application.LoadLevel(1);
            }
        }
	}
    public void NewGame()
    {
        cutscene.SetActive(true);

        GameData.current_scene = 1;
        GameData.previous_scene = 1;
        for (int i = 0; i < GameData.events_complete.Length; i++) GameData.events_complete[i] = false;
        for (int i = 0; i < GameData.gems_receive.Length; i++) GameData.gems_receive[i] = false;

        StartCoroutine(DelayBeforeGo());
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

    IEnumerator DelayBeforeGo ()
    {
        yield return new WaitForSeconds(18.5f);
        Application.LoadLevel(1);
    }
}
